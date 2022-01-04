using MessagePack;
using RabbitMQ.Client;

namespace Report.Business
{
    public class RabbitMQService : IMQService
    {
        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "127.0.0.1",
            UserName = "administrator",
            Password = "4jm5eX4b",
        };
        public void SendNewReportRequest(int reportId)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "NewReportQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    var queueData = new Dictionary<string, dynamic>();
                    queueData.Add("reportId", reportId);
                    var body = MessagePackSerializer.Serialize(queueData);
                    channel.BasicPublish(exchange: "", routingKey: "NewReportQueue", basicProperties: null, body: body);
                }
            }
        }
    }
}
