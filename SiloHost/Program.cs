using Orleans.Configuration;

var hostBuilder = Host.CreateDefaultBuilder()
    .UseOrleans(siloBuilder =>
    {
        siloBuilder
        .UseLocalhostClustering()
        .AddMemoryGrainStorageAsDefault()
        .UseDashboard()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "StocksTickerApp";
        })
        .Configure<EndpointOptions>(options =>
        {
            options.SiloPort = 11111;
            options.GatewayPort = 30000;
        })
        .ConfigureLogging(logging => logging.AddConsole());
    });

var host = hostBuilder.Build();
await host.RunAsync();