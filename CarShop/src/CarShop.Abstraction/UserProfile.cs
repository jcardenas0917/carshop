using IkeMtz.NRSRx.Core.Models;
using System;

namespace CarShop.Abstraction
{
  public class UserProfile : IIdentifiable
  {
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
        public string Sub { get; set; }
    }
}
