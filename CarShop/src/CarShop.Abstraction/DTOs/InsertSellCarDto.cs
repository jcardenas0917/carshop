using IkeMtz.NRSRx.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Abstraction.DTOs
{
  public class InsertSellCarDto
  {
    public Guid? Id { get; set; }
    [Required]
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }

        public SellCar ToSellCar()
    {
      var result = SimpleMapper<InsertSellCarDto, SellCar>.Instance.Convert(this);
      result.Id = Id ?? Guid.NewGuid();
      return result;
    }
  }
}
