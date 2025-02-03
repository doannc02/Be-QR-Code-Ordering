using Microsoft.EntityFrameworkCore;
using OrderEats.Library.Models.Entities;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Common.Extension;
using OrderEats.Library.Infrastructure.Repository;
using OrderEats.Library.Application.Services;
using OrderEats.Library.Application.Mappers;
using OrderEats.Main.API.Services;
using OrderEats.Library.Application.Mapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrderEats.Main.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 🟢 Cấu hình CORS trước khi gọi app.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Địa chỉ frontend
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// 🟢 Thêm SignalR
builder.Services.AddSignalR();

// 🟢 Kiểm tra và lấy Connection String từ biến môi trường hoặc cấu hình
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
//   ?? builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is not set.");
}

// 🟢 Thêm DbContext
builder.Services.AddDbContext<OrderEatsDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("OrderEats.Library.Infrastructure")
    ));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

// 🟢 Đăng ký Repository và Service
builder.Services.AddScoped<IGenercRepository<Order>, GenericRepository<Order>>();
builder.Services.AddScoped<IGenercRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<OrderMapper>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<FoodItemMapper>();
builder.Services.AddScoped<IFoodItemService, FoodItemService>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<TableMapper>();

// 🟢 Thêm Middleware cần thiết
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();

var app = builder.Build();

// 🟢 Cấu hình Swagger cho môi trường phát triển
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

// 🟢 Middleware Pipeline

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseRouting(); // 🔹 Thêm dòng này để middleware chạy đúng thứ tự
app.UseCors("AllowLocalhost");
app.UseAuthorization();

app.MapControllers();
app.MapHub<OrderHub>("/orderHub");

app.Run();
