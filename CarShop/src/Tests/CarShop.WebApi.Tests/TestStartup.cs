using CarShop.WebApi.Data;
using IkeMtz.NRSRx.Core.Unigration;
using IkeMtz.NRSRx.Core.Unigration.WebApi;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.WebApi.Tests
{
  public class TestStartup : CoreWebApiUnigrationTestStartup<Startup>
  {
    public TestStartup(IConfiguration configuration) : base(new Startup(configuration))
    {
    }

    public override void SetupDatabase(IServiceCollection services, string connectionString)
    {
      services.SetupTestDbContext<CarShopContext>();
    }

    public override void SetupPublishers(IServiceCollection services)
    {
      new PublisherIntegrationTester<CarShop, Message, string>().RegisterDependencies(services);
    }
  }
}
