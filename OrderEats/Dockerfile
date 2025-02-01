# Sử dụng .NET SDK image để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy file .csproj vào đúng thư mục
COPY ["BE-QR-Code-Ordering/OrderEats/OrderEats.csproj", "./"]

# Thực hiện restore project
RUN dotnet restore "OrderEats/OrderEats.csproj"

# Sao chép toàn bộ mã nguồn
COPY . .

# Chuyển đến thư mục chứa mã nguồn của OrderEats
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
