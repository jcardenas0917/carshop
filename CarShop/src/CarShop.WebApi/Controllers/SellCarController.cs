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
  public class SellCarController : ControllerBase
  {
    private readonly ICarShopContext _ctx;

    public SellCarController(ICarShopContext ctx)
    {
      _ctx = ctx;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery]Guid id)

    {
           return Ok(await _ctx.SellCars
         .FirstOrDefaultAsync(t => t.Id == id));
         
    }

    // Post api/UserProfile
    [HttpPost]
    [ProducesResponseType(Status200OK, Type = typeof(SellCar))]
    [ValidateModel]
    public async Task<ActionResult> Post([FromBody] InsertSellCarDto value)
    {
      var sellCar = value.ToSellCar();
      _ = _ctx.SellCars.Add(sellCar);
      _ = await _ctx.SaveChangesAsync();
      return Ok(sellCar);
    }

    // Put api/UserProfile
    [HttpPut]
    [ProducesResponseType(Status200OK, Type = typeof(SellCar))]
    [ValidateModel]
    public async Task<ActionResult> Put([FromQuery] Guid id, [FromBody] UpdateSellCarDto value)
    {
      var sellCar = await _ctx.SellCars
         .FirstOrDefaultAsync(t => t.Id == id);

      if (null == sellCar)
      {
        return NotFound("Invalid Id");
      }
      else
      {
        SimpleMapper<UpdateSellCarDto, SellCar>.Instance.ApplyChanges(value, sellCar);
        _ = await _ctx.SaveChangesAsync();
        return Ok(sellCar);
      }
    }

        // Delete api/UserProfile
        [HttpDelete]
    [ProducesResponseType(Status200OK, Type = typeof(SellCar))]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
      var sellCar = await _ctx.SellCars
          .FirstOrDefaultAsync(t => t.Id == id);
      _ = _ctx.Remove(sellCar);
      _ = await _ctx.SaveChangesAsync();
      return Ok(sellCar);
    }
  }
}
