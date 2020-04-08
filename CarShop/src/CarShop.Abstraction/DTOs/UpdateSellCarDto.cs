using IkeMtz.NRSRx.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Abstraction.DTOs
{
  public class UpdateSellCarDto : IIdentifiable
  {
    [Required]
    public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public void UpdateCarShop(SellCar sell)
    {
      SimpleMapper<UpdateSellCarDto, SellCar>.Instance.ApplyChanges(this, sell);
            sell.Id = Id;
    }
  }
}
