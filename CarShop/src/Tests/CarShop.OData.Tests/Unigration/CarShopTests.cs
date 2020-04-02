using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.Unigration;
using CarShop.Abstraction;
using CarShop.OData.Data;
using Shared.AspNetCore;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarShop.OData.Tests.Unigration.OData
{
  [TestClass]
  public class CarShopTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetCarShopTest()
    {
      var objA = new CarShop()
      {
        Id = "ID-123",
        TenantId = "SMLLC",
        CreatedOnUtc = DateTime.UtcNow,
      };
      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<CarShopContext>(x, db =>
            {
              db.CarShop.Add(objA);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken(new[] { new Claim(TenantFilterAttribute.TenantIdsClaimType, "SMLLC") }));

      var resp = await client.GetStringAsync($"odata/v1/CarShop?tid=SMLLC");
      TestContext.WriteLine($"Server Reponse: {resp}");
      Assert.IsFalse(resp.ToLower().Contains("updatedby"));
      var envelope = JsonConvert.DeserializeObject<ODataEnvelope<CarShop, string>>(resp);
      Assert.AreEqual(objA.CreatedOnUtc, envelope.Value.First().CreatedOnUtc.ToUniversalTime());
    }
  }
}
