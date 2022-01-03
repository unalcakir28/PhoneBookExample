using Report.BackgroundWorker;
using Report.Business;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<IReportService, ReportService>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    })
    .Build();

await host.RunAsync();
