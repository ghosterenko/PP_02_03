var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(); 
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

app.MapGet("/api/bonus", (double amount) => {
    
    // Начисляем 20 бонусных баллов за каждые 10000 рублей
    int points = (int)(amount / 10000 * 20);
    // Возвращаем количество бонусных баллов
    return new { bonusPoints = points };
});
// Порт 5004
app.Run("http://localhost:5004");
