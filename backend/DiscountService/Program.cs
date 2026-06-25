var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

app.MapGet("/api/discount", (string promo) =>
{
    int percent = 0;

    if (promo == "SGD10")
        percent = 10;
    if(promo == "SGD20")
        percent = 20;

    return new { discountPercent = percent };

});

app.Run("http://localhost:5002");
