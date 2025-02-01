# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderEats/OrderEats.Main.API/OrderEats.Main.API.csproj", "OrderEats/OrderEats.Main.API/"]
COPY ["OrderEats/OrderEats.Library.Application/OrderEats.Library.Application.csproj", "OrderEats/OrderEats.Library.Application/"]
COPY ["OrderEats/OrderEats.Library.Common/OrderEats.Library.Common.csproj", "OrderEats/OrderEats.Library.Common/"]
COPY ["OrderEats/OrderEats.Library.Infrastructure/OrderEats.Library.Infrastructure.csproj", "OrderEats/OrderEats.Library.Infrastructure/"]
COPY ["OrderEats/OrderEats.Library.Models/OrderEats.Library.Models.csproj", "OrderEats/OrderEats.Library.Models/"]
COPY . .
WORKDIR "/src/OrderEats/OrderEats.Main.API"
RUN dotnet build "OrderEats.Main.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "OrderEats.Main.API.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderEats.Main.API.dll"]
