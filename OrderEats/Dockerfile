# Sử dụng .NET SDK image để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderEats/OrderEats.csproj", "OrderEats/"]
RUN dotnet restore "OrderEats/OrderEats.csproj"
COPY . .
WORKDIR "/src/OrderEats"
RUN dotnet build "OrderEats.csproj" -c Release -o /app/build

# Publish ứng dụng
FROM build AS publish
RUN dotnet publish "OrderEats.csproj" -c Release -o /app/publish

# Kết hợp và chỉ định lệnh để chạy ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderEats.dll"]
