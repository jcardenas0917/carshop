using IkeMtz.NRSRx.Core.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;
using CarShop.Abstraction;

namespace CarShop.OData.Configuration
{
  public class ModelConfiguration : IModelConfiguration
  {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
    {
      _ = ODataConfigurationBuilder<UserProfile>.EntitySetBuilder(builder);
    }
  }
}
