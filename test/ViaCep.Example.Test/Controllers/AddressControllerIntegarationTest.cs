using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ViaCep.Example.Core.Common;
using ViaCep.Example.Core.Models;
using ViaCep.Example.Test.Configuration;
using Xunit;

namespace ViaCep.Example.Test.Controllers
{
    public class AddressControllerIntegarationTest : BaseIntegrationTest, IClassFixture<BaseTestFixture>
    {
        private const string BaseUrl = "/api/Address/zip-code/";

        public AddressControllerIntegarationTest(BaseTestFixture fixture)
            : base(fixture)
        { }

        [Theory]
        [InlineData(91420270)]
        [InlineData(91120090)]
        [InlineData(01001000)]
        [InlineData(29102020)]
        [InlineData(31680320)]
        [InlineData(29102320)]
        [InlineData(23555306)]
        [InlineData(22020989)]
        [InlineData(01310100)]
        [InlineData(01223001)]
        public async Task ShouldReturnAddress(uint zipCpde)
        {
            var response = await Client.GetAsync($"{BaseUrl}{zipCpde}");
            response.EnsureSuccessStatusCode();

            var dataString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ServiceResult<Address>>(dataString);

            data.Status.Should().Be(ServiceResult.StatusResult.Ok);
        }

        [Theory]
        [InlineData("91420-270")]
        [InlineData("91120-090")]
        [InlineData("01001-000")]
        [InlineData("29102-020")]
        [InlineData("31680-320")]
        [InlineData("29102-320")]
        [InlineData("23555-306")]
        [InlineData("22020-989")]
        [InlineData("01310-100")]
        [InlineData("01223-001")]
        public async Task DontShouldReturnAddress(string zipCpde)
        {
            var response = await Client.GetAsync($"{BaseUrl}{zipCpde}");
            response.EnsureSuccessStatusCode();

            var dataString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ServiceResult>(dataString);

            data.Status.Should().Be(ServiceResult.StatusResult.Error);
        }
    }
}
