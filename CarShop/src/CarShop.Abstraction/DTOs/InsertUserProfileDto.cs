using IkeMtz.NRSRx.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Abstraction.DTOs
{
  public class InsertUserProfileDto
  {
    public Guid? Id { get; set; }
    [Required]
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }

    public string City { get; set; }
    public string State { get; set; }
        public string Sub { get; set; }
        public UserProfile ToUserProfile()
    {
      var result = SimpleMapper<InsertUserProfileDto, UserProfile>.Instance.Convert(this);
      result.Id = Id ?? Guid.NewGuid();
      return result;
    }
  }
}
