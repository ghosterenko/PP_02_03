using System.Runtime.CompilerServices;

namespace DeliveryService.Models
{
    public class CityDelivery
    {
        public int Id { get; set; }
        public string City { get; set; } = "";
        public int DeliveryPrice { get; set; }
    }
}
