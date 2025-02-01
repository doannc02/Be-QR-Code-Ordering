# Chọn image .NET 6 SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Sử dụng image .NET SDK để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderEats/OrderEats.csproj", "OrderEats/"]
RUN dotnet restore "OrderEats/OrderEats.csproj"
COPY . .
WORKDIR "/src/Be-QR-Code-Ordering"
RUN dotnet build "OrderEats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderEats.csproj" -c Release -o /app/publish

# Kết hợp các bước và chỉ định lệnh để chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderEats.dll"]
