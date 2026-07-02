var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());
app.MapGet("/api/price", (double area, string type) =>
{
    int price = 0;
    // Цена за квадратный метр: для бани 18000, для дома 24000
    if (type == "Баня")
        price = 18000;
    else price = 24000;
    // Расчёт базовой стоимости = площадь * цена за метр - ответ в формате Json
    return new { basePrice = area * price };
});

app.Run("http://localhost:5001");
