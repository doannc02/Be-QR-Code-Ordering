using Microsoft.EntityFrameworkCore;
using OrderEats.Library.Models.Entities;
using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Common.Extension;
using OrderEats.Library.Infrastructure.Repository;
using OrderEats.Library.Application.Services;
using OrderEats.Library.Application.Mappers;
using OrderEats.Library.Application.Mapper;
using OrderEats.Main.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình CORS trước khi gọi app.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Địa chỉ frontend
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

// Thêm SignalR
builder.Services.AddSignalR();

// Thêm DbContext
builder.Services.AddDbContext<OrderEatsDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")),
        b => b.MigrationsAssembly("OrderEats.Library.Models")
    ));

// Thêm các service khác
builder.Services.AddScoped<IGenercRepository<Order>, GenericRepository<Order>>();
builder.Services.AddScoped<IGenercRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<OrderMapper>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();
builder.Services.AddScoped<FoodItemMapper>();
builder.Services.AddScoped<IFoodItemService, FoodItemService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();

var app = builder.Build();

// Cấu hình Swagger cho môi trường phát triển
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseAuthorization();

// Sử dụng CORS trước khi các middleware khác
app.UseCors("AllowLocalhost");

app.MapControllers();
app.MapHub<OrderHub>("/orderHub");

app.Run();
