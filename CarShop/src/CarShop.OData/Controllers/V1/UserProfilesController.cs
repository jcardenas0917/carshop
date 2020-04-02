using CarShop.Abstraction;
using CarShop.OData.Data;
using IkeMtz.NRSRx.Core.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace CarShop.OData.Controllers.V1
{
  [ApiVersion(VersionDefinitions.v1_0)]
  [ODataRoutePrefix("UserProfiles")]
  [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 600)]
  public class UserProfilesController : ODataController
  {
    private readonly ICarShopContext _ctx;

    public UserProfilesController(ICarShopContext ctx) => _ctx = ctx;

    [ODataRoute]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ODataEnvelope<UserProfile>), Status200OK)]
    [EnableQuery(MaxTop = 10, AllowedQueryOptions = All)]
    public IEnumerable<UserProfile> Get()
    {
      return _ctx.UserProfiles;
    }
  }
}
