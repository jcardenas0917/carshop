using CarShop.WebApi.Data;
using IkeMtz.NRSRx.Core.WebApi;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace CarShop.WebApi
{
  public class Startup : CoreWebApiStartup
  {
    public override string MicroServiceTitle => $"{nameof(CarShop)} WebApi Microservice";
    public override Assembly StartupAssembly => typeof(Startup).Assembly;

    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    [ExcludeFromCodeCoverage]
    public override void SetupDatabase(IServiceCollection services, string connectionString)
    {
      _ = services
       .AddDbContext<CarShopContext>(x => x.UseSqlServer(connectionString))
       .AddEntityFrameworkSqlServer();
    }

    public override void SetupMiscDependencies(IServiceCollection services)
    {
      _ = services.AddMediatR(GetType().Assembly)
        .AddScoped<ICarShopContext, CarShopContext>();
    }
  }
}
