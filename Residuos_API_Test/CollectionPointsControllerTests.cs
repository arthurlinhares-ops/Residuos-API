using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace RecyclingManagementAPI.Tests
{
    public class CollectionPointsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CollectionPointsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsStatusCode200()
        {
            var response = await _client.GetAsync("/api/collectionpoints?page=1&pageSize=10");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}