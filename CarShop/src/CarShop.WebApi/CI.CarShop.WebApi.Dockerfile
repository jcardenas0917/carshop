FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY ./CarShop.WebApi .
EXPOSE 80
ENTRYPOINT ["dotnet", "CarShop.WebApi.dll"]
