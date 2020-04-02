using Microsoft.EntityFrameworkCore;
using CarShop.Abstraction;

namespace CarShop.OData.Data
{
  public class CarShopContext : DbContext, ICarShopContext
  {
    public CarShopContext(DbContextOptions<CarShopContext> options)
        : base(options)
    { }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }
  }
}
