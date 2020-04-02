using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CarShop.WebApi
{
  [ExcludeFromCodeCoverage]  //This is part of the dotnet aspnet.core project template and typically should not be changed
  public static class Program
  {
    public static void Main(string[] args) //NOSONAR
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
      return WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
    }
  }
}
