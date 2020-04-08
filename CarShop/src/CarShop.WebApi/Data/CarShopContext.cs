using IkeMtz.NRSRx.Core.EntityFramework;
using CarShop.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarShop.WebApi.Data
{
  public class CarShopContext : AuditableDbContext, ICarShopContext
  {
    public CarShopContext(DbContextOptions<CarShopContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    { }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<SellCar> SellCars { get; set; }
    }
}
