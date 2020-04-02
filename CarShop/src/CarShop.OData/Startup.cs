using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using IkeMtz.NRSRx.Core.OData;
using CarShop.OData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.OData
{
  public class Startup : CoreODataStartup
  {
    public override string MicroServiceTitle => $"{nameof(CarShop)} OData Microservice";
    public override Assembly StartupAssembly => typeof(Startup).Assembly;

    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    [ExcludeFromCodeCoverage]
    public override void SetupDatabase(IServiceCollection services, string connectionString)
    {
      _ = services
       .AddDbContextPool<CarShopContext>(x => x.UseSqlServer(connectionString))
       .AddEntityFrameworkSqlServer();
    }

    public override void SetupMiscDependencies(IServiceCollection services)
    {
      _ = services.AddScoped<ICarShopContext, CarShopContext>();
    }
  }
}
