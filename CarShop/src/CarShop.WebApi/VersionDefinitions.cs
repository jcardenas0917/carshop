using IkeMtz.NRSRx.Core.Web;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CarShop.WebApi
{
  [ExcludeFromCodeCoverage]
  public class VersionDefinitions : IApiVersionDefinitions
  {
#pragma warning disable CA1707 // Identifiers should not contain underscores
    public const string v1_0 = "1.0";
#pragma warning restore CA1707 // Identifiers should not contain underscores

    public IEnumerable<string> Versions => new[] { v1_0 };
  }
}
