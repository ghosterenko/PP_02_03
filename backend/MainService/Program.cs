using MainService.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddHttpClient();
var app = builder.Build();
app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod());

app.MapGet("/api/calculate", async (HttpClient client, double area, string type, string city, string promo) =>
{
    // Получаем базовую цену от PriceService (порт 5001)
    var priceResponce = await client.GetStringAsync($"http://localhost:5001/api/price?area={area}&type={type}");
    var priceData = JsonSerializer.Deserialize<PriceData>(priceResponce);
    double basePrice = priceData.basePrice;
    // Получаем скидку от DiscountService (порт 5002)
    var discountResponse = await client.GetStringAsync($"http://localhost:5002/api/discount?promo={promo}");
    var discountData = JsonSerializer.Deserialize<DiscountData>(discountResponse);
    int discountPercent = discountData.discountPercent;
    // Получаем стоимость доставки от DeliveryService (порт 5003)
    var deliveryResponse = await client.GetStringAsync($"http://localhost:5003/api/delivery?city={city}");
    var deliveryData = JsonSerializer.Deserialize<DeliveryData>(deliveryResponse);
    int deliveryPrice = deliveryData.delivery;
    // Рассчитываем сумму скидки в рублях
    double discountAmount = basePrice * discountPercent / 100.0;
    // Вычитаем скидку из базовой цены
    double priceWithDiscount = basePrice - discountAmount;
    // Получаем бонусные баллы от BonusService (порт 5004)
    var bonusResponse = await client.GetStringAsync($"http://localhost:5004/api/bonus?amount={priceWithDiscount}");
    var bonusData = JsonSerializer.Deserialize<BonusData>(bonusResponse);
    int bonusPoints = bonusData.bonusPoints;
    //  Собираем итоговый ответ: цена, скидка, доставка, бонусы, итого в JSON
    return new
    {
        basePrice,
        discountPercent,
        discountAmount,
        delivery = deliveryPrice,
        bonusPoints,
        total = priceWithDiscount + deliveryPrice
    };
});

app.Run("http://localhost:5000");
