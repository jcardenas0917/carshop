using IkeMtz.NRSRx.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Abstraction.DTOs
{
  public class UpdateUserProfileDto : IIdentifiable
  {
    [Required]
    public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public void UpdateCarShop(UserProfile profile)
    {
      SimpleMapper<UpdateUserProfileDto, UserProfile>.Instance.ApplyChanges(this, profile);
      profile.Id = Id;
    }
  }
}
