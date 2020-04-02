using System;
using CarShop.Abstraction.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarShop.WebApi.Tests.Unit
{
  [TestClass]
  public class InsertCarShopDtoTests
  {
    [TestMethod]
    [TestCategory("Unit")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void UpdateCarShopDto_InvalidArgs_ThrowsArgumenNullException()
    {
      var dto = new UpdateCarShopDto();
      dto.UpdateCarShop(null);
    }
  }
}
