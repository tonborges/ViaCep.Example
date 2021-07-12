using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace ViaCep.Example.Test.Configuration
{
    public abstract class BaseIntegrationTest
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;
        protected readonly BaseTestFixture Fixture;

        public BaseIntegrationTest(BaseTestFixture fixture)
        {
            Fixture = fixture;
            Server = fixture.Server;
            Client = fixture.Client;
        }
    }
}
