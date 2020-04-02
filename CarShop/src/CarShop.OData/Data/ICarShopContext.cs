using CarShop.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CarShop.OData.Data
{
  public interface ICarShopContext
  {
    DbSet<UserProfile> UserProfiles { get; set; }
  }
}
