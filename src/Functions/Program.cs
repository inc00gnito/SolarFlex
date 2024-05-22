using Functions.Data;
using Functions.Options;
using Functions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, configBuilder) =>
    {
        configBuilder
        .AddJsonFile("local.settings.json", optional: false, reloadOnChange: true)
        .AddUserSecrets(Assembly.GetExecutingAssembly(), false)
        .AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddLogging();
        services.AddScoped<IDatabaseService, DatabaseService>();

        services.AddHttpClient<ISolarPowerService, SolarPowerService>("SolarPowerService", client =>
        {
            client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("SolarPower:BASE_URL") ?? "");
        });

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionStrings:DatabaseContext") ?? "");
        });

    })
    .Build();

host.Run();
