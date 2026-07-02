var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

app.MapGet("/api/discount", (string promo) =>
{
    int percent = 0;
    // Проверяем промокод и назначаем соответствующую скидку
    if (promo == "SGD10")
        percent = 10;
    if(promo == "SGD20")
        percent = 20;
    // Возвращаем размер скидки в процентах
    return new { discountPercent = percent };

});

app.Run("http://localhost:5002");
