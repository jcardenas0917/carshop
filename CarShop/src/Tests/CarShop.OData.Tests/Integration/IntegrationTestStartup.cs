using IkeMtz.NRSRx.Core.Unigration;
using CarShop.OData.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace CarShop.OData.Tests.Integration
{
  public class IntegrationTestStartup : CoreODataIntegrationTestStartup<Startup, ModelConfiguration>
  {
    public IntegrationTestStartup(IConfiguration configuration)
        : base(new Startup(configuration))
    {
    }
    public override void SetupAuthentication(AuthenticationBuilder builder)
    {
      CoreTestServerExtensions.SetupTestAuthentication(builder, Configuration, TestContext);
    }
  }
}
