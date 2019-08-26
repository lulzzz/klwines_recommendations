using System;
using Orleans.Configuration;
using Orleans.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Domain;
using Orleans;
using Grains;

namespace Silo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var silo = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "server";
                })
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(RecommendationGrain).Assembly).WithReferences())
                //.AddMemoryGrainStorageAsDefault()
                .ConfigureLogging(logging => logging.AddConsole())
                .AddMongoDBGrainStorageAsDefault(options =>
                {
                    options.DatabaseName = "ProductRecommendations";
                    options.ConnectionString = "mongodb://localhost:27017/admin";
                })
                .Build();

            await silo.StartAsync();

            Console.WriteLine("Server has started. Press any key to exit.");
            Console.ReadKey();
            await silo.StopAsync();
        }
    }
}
