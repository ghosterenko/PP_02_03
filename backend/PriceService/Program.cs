var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());
app.MapGet("/api/price", (double area, string type) =>
{
    int price = 0;
    if (type == "Баня")
        price = 18000;
    else price = 24000;

    return new { basePrice = area * price };
});

app.Run("http://localhost:5001");
