using DeliveryService.Data;
using DeliveryService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    db.Cities.AddRange(
        new CityDelivery { City = "Екатеринбург", DeliveryPrice = 15000 },
        new CityDelivery { City = "Нижний Тагил", DeliveryPrice = 18000 },
        new CityDelivery { City = "Каменск-Уральский", DeliveryPrice = 16000 },
        new CityDelivery { City = "Первоуральск", DeliveryPrice = 14000 },
        new CityDelivery { City = "Серов", DeliveryPrice = 22000 },
        new CityDelivery { City = "Новоуральск", DeliveryPrice = 17000 },
        new CityDelivery { City = "Пермь", DeliveryPrice = 28000 }
    );
    db.SaveChanges();
}


app.MapGet("/api/delivery", async (string city, AppDbContext db) =>
{
    // Ищем город в базе данных
    var cityData = await db.Cities.FirstOrDefaultAsync(c => c.City == city);
     // Если город найден — берём цену доставки, иначе 40000
    int price = cityData?.DeliveryPrice ?? 40000;
    // Возвращаем стоимость доставки
    return new { delivery = price };
});

app.Run("http://localhost:5003");
