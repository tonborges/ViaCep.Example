using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using ViaCep.Example.Api;

namespace ViaCep.Example.Test.Configuration
{
    public class BaseTestFixture: IDisposable
    {
        public readonly TestServer Server;
        public readonly HttpClient Client;
        public readonly IConfigurationRoot Configuration;

        public BaseTestFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Server = new TestServer(new WebHostBuilder()
                                        .UseStartup<Startup>()
                                        .UseConfiguration(Configuration));
            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}