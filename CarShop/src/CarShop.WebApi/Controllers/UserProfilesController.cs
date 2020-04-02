using CarShop.Abstraction;
using CarShop.Abstraction.DTOs;
using CarShop.WebApi.Data;
using IkeMtz.NRSRx.Core.Models;
using IkeMtz.NRSRx.Core.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace CarShop.WebApi.Controllers
{
  [Route("api/v{version:apiVersion}/[controller].{format}"), FormatFilter]
  [ApiVersion(VersionDefinitions.v1_0)]
  [ApiController]
  public class UserProfileController : ControllerBase
  {
    private readonly ICarShopContext _ctx;

    public UserProfileController(ICarShopContext ctx)
    {
      _ctx = ctx;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]string sub)

    {
           return Ok(await _ctx.UserProfiles
         .FirstOrDefaultAsync(t => t.Sub == sub));
         
    }

    // Post api/UserProfile
    [HttpPost]
    [ProducesResponseType(Status200OK, Type = typeof(UserProfile))]
    [ValidateModel]
    public async Task<ActionResult> Post([FromBody] InsertUserProfileDto value)
    {
      var userProfile = value.ToUserProfile();
      _ = _ctx.UserProfiles.Add(userProfile);
      _ = await _ctx.SaveChangesAsync();
      return Ok(userProfile);
    }

    // Put api/UserProfile
    [HttpPut]
    [ProducesResponseType(Status200OK, Type = typeof(UserProfile))]
    [ValidateModel]
    public async Task<ActionResult> Put([FromQuery] Guid id, [FromBody] UpdateUserProfileDto value)
    {
      var userProfile = await _ctx.UserProfiles
         .FirstOrDefaultAsync(t => t.Id == id);

      if (null == userProfile)
      {
        return NotFound("Invalid Id");
      }
      else
      {
        SimpleMapper<UpdateUserProfileDto, UserProfile>.Instance.ApplyChanges(value, userProfile);
        _ = await _ctx.SaveChangesAsync();
        return Ok(userProfile);
      }
    }

        // Delete api/UserProfile
        [HttpDelete]
    [ProducesResponseType(Status200OK, Type = typeof(UserProfile))]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
      var userProfile = await _ctx.UserProfiles
          .FirstOrDefaultAsync(t => t.Id == id);
      _ = _ctx.Remove(userProfile);
      _ = await _ctx.SaveChangesAsync();
      return Ok(userProfile);
    }
  }
}
