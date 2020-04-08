using IkeMtz.NRSRx.Core.Models;
using System;

namespace CarShop.Abstraction
{
    public class SellCar : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}