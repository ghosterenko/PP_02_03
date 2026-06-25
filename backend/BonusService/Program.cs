var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(); 
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

app.MapGet("/api/bonus", (double amount) => {
    int points = (int)(amount / 10000 * 20);
    return new { bonusPoints = points };
});

app.Run("http://localhost:5004");
