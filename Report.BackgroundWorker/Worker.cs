using MessagePack;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.Business;

namespace Report.BackgroundWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IReportService _reportService;
        private readonly IContactService _contactService;

        public Worker(ILogger<Worker> logger, IReportService reportService, IContactService contactService)
        {
            _logger = logger;
            _reportService = reportService;
            _contactService = contactService;
        }

        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "127.0.0.1",
            UserName = "administrator",
            Password = "4jm5eX4b",
        };

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();
                channel.BasicQos(0, 1, false);
                channel.QueueDeclare(queue: "NewReportQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                var NewReportQueue_Consumer = new EventingBasicConsumer(channel);

                NewReportQueue_Consumer.Received += async (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var queueData = MessagePackSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                        int reportId = queueData["reportId"];

                        var report = await _reportService.GetById(reportId);
                        var contacts = await _contactService.GetAllByLocation(report.RequestLocation);

                        var locationContactCount = contacts.Count();
                        var locationPhoneCount = contacts.Sum(w => w.ContactDetails.Where(w => w.ContactDetailType == Business.Dtos.ContactServiceDtos.ContactDetailType.Phone).Count());

                        /* 
                         *  locationContactCount ve locationPhoneCount deðerleri excel olarak bir CDN'e kaydedilir
                         *  ve cnd'in linki report nesnesini Value deðiþkenine girilerek durumu Tamamlanmýþ olarak veritabanýna kaydedilir.
                         */

                        report.Value = "Remote CDN Url";
                        report.ReportStatus = Entity.ReportStatus.Done;
                        await _reportService.Update(report);

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "BPQ_ACC Queue Error");
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                };

                channel.BasicConsume(queue: "NewReportQueue", autoAck: false, consumer: NewReportQueue_Consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}