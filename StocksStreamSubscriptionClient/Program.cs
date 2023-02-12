using Orleans.Configuration;

var hostBuilder = Host.CreateDefaultBuilder()
    .UseOrleansClient(client =>
    {
        client
            .UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "StocksTickerApp";
            });
    });

var host = hostBuilder.Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();