using System;
using CarShop.WebApi.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarShop.WebApi.Tests.Unit
{
  [TestClass]
  public class CarShopRequestTests
  {
    [TestMethod]
    [TestCategory("Unit")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void InsertCarShopRequest_InvalidDto_ThrowsArgumenNullException()
    {
      var request = new InsertCarShopRequest(string.Empty, null);
    }

    [TestMethod]
    [TestCategory("Unit")]
    [ExpectedException(typeof(ArgumentNullException))]
    public void UdpateCarShopRequest_InvalidDto_ThrowsArgumenNullException()
    {
      var request = new UpdateCarShopRequest(string.Empty, string.Empty, null);
    }
  }
}
