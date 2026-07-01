var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run("http://localhost:5005");