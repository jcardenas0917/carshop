using CarShop.OData.Configuration;
using CarShop.OData.Data;
using IkeMtz.NRSRx.Core.Unigration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.OData.Tests
{
  public class TestStartup
        : CoreODataUnigrationTestStartup<Startup, ModelConfiguration>
  {
    public TestStartup(IConfiguration configuration) : base(new Startup(configuration))
    {
    }
    public override void SetupDatabase(IServiceCollection services, string connectionString)
    {
      services.SetupTestDbContext<CarShopContext>();
    }
  }
}
