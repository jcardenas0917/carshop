using CarShop.Abstraction;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace CarShop.OData.Tests.Integration
{
  [TestClass]
  public class IntegrationTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Integration")]
    public async Task LoadCarShopAsync()
    {
      using var srv = new TestServer(TestHostBuilder<Startup, IntegrationTestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());
      var resp = await client.GetAsync($"odata/v1/{nameof(CarShop)}s?tid=smllc");
      Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
    }

  }
}
