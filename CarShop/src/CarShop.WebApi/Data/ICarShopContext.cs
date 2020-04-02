using CarShop.Abstraction;
using IkeMtz.NRSRx.Core.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CarShop.WebApi.Data
{
  public interface ICarShopContext : IAuditableDbContext
  {
    DbSet<UserProfile> UserProfiles { get; set; }
  }
}
