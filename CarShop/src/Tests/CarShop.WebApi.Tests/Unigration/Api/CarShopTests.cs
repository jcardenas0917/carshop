using CarShop.Abstraction.Enums;
using CarShop.WebApi.Data;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarShop.WebApi.Tests.Unigration.Api
{
  [TestClass]
  public class CarShopTests : BaseUnigrationTests
  {
    [TestMethod]
    [TestCategory("Unigration")]
    public async Task GetCarShop_Success()
    {
      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>());
      var client = srv.CreateClient();
      var resp = await client.GetAsync($"api/v1/CarShop.json");

      Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
      var result = await resp.Content.ReadAsStringAsync();

      Assert.AreEqual("\"NRSRx CarShop MicroService Controller\"", result);
    }

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task InsertCarShop_ValidArgs_Success()
    {
      var carShop = CreateCarShop();

      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.PostAsJsonAsync("api/v1/CarShop.json?tid=mcorp", carShop);
      resp.EnsureSuccessStatusCode();
      var result = await DeserializeResponseAsync<CarShop>(resp);
      Assert.AreEqual("Integration Tester", result.CreatedBy);

      var dbContext = srv.GetDbContext<CarShopContext>();
      var dbItem = await dbContext.CarShop.FirstOrDefaultAsync(e => e.Id == carShop.Id);

      Assert.IsNotNull(dbItem);
      Assert.AreEqual(result.CreatedOnUtc, dbItem.CreatedOnUtc);
    }

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task UpdateCarShop_ValidArgs_Success()
    {
      var carShop = CreateCarShop();
      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>()
          .ConfigureTestServices(x =>
          {
            ExecuteOnContext<CarShopContext>(x, db =>
            {
              db.CarShop.Add(carShop);
            });
          })
       );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());
      carShop.Description = "Updated Mock Description";

      var resp = await client.PutAsJsonAsync($"api/v1/CarShop.json?tid=mcorp&id={carShop.Id}", carShop);
      resp.EnsureSuccessStatusCode();
      var result = await DeserializeResponseAsync<CarShop>(resp);

      Assert.AreEqual("Integration Tester", result.UpdatedBy);
      Assert.AreEqual(carShop.Description, result.Description);

      var dbContext = srv.GetDbContext<CarShopContext>();
      var dbItem = await dbContext.CarShop.FirstOrDefaultAsync(e => e.Id == carShop.Id);

      Assert.IsNotNull(dbItem);
      Assert.AreEqual(result.UpdatedOnUtc, dbItem.UpdatedOnUtc);
      Assert.AreEqual("Integration Tester", dbItem.UpdatedBy);
    }

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task UpdateCarShop_InvalidCarShopId_ReturnsNotFound()
    {
      var carShop = CreateCarShop();
      carShop.Id = "ID-1";

      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>());
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken(new[] { new Claim(TenantFilterAttribute.TenantIdsClaimType, "mcorp") }));

      var resp = await client.PutAsJsonAsync($"api/v1/CarShop.json?tid=mcorp&id={carShop.Id}", carShop);

      Assert.AreEqual(HttpStatusCode.NotFound, resp.StatusCode);
      Assert.AreEqual("\"CarShop Not Found\"", await resp.Content.ReadAsStringAsync());
    }

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task DeleteCarShop_ValidArgs_Success()
    {
      var carShop = CreateCarShop();
      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<CarShopContext>(x, db =>
          {
            db.CarShop.Add(carShop);
          });
        })
      );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.DeleteAsync($"api/v1/CarShop.json?tid=mcorp&id={carShop.Id}");
      resp.EnsureSuccessStatusCode();
      var result = await DeserializeResponseAsync<CarShop>(resp);

      Assert.IsNotNull(result);
    }

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task DeleteCarShop_EmptyCarShopId_ReturnsBadRequest()
    {
      var carShop = CreateCarShop();
      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<CarShopContext>(x, db =>
          {
            db.CarShop.Add(carShop);
          });
        })
      );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());

      var resp = await client.DeleteAsync($"api/v1/CarShop.json?tid=mcorp&id={string.Empty}");
      Assert.AreEqual(resp.StatusCode, HttpStatusCode.BadRequest);
    }

    [TestMethod]
    [TestCategory("Unigration")]
    public async Task DeleteCarShop_UnknownCarShopId_ReturnsNotFound()
    {
      var carShop = CreateCarShop();
      using var srv = new TestServer(TestHostBuilder<Startup, TestStartup>()
        .ConfigureTestServices(x =>
        {
          ExecuteOnContext<CarShopContext>(x, db =>
          {
            db.CarShops.Add(carShop);
          });
        })
      );
      var client = srv.CreateClient();
      GenerateAuthHeader(client, GenerateTestToken());
      var unknownId = "Unknown";

      var resp = await client.DeleteAsync($"api/v1/CarShop.json?tid=mcorp&id={unknownId}");
      Assert.AreEqual(resp.StatusCode, HttpStatusCode.NotFound);
    }

    private static CarShop CreateCarShop()
    {
      return new CarShop
      {
        Id = "ID-123",
        Description = "Mock Description",
        TenantId = "MCORP",
        FrequencyInDays = 14,
        StartOfWeek = DayOfWeek.Monday,
        PayWeekOccursOn = PayWeekOccursOn.OddAndEvenWeeks
      };
    }
  }
}
