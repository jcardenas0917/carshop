FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY ./CarShop.OData .
EXPOSE 80
ENTRYPOINT ["dotnet", "CarShop.OData.dll"]
