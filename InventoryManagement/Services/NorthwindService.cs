using System.Text.Json;
using InventoryManagement.Models.Northwind;

namespace InventoryManagement.Northwind
{
    public class NorthwindService: INorthwindService
    {
        private readonly IWebHostEnvironment _env;

        public NorthwindService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<List<OrdersType>> GetOrders()
        {
            var options = new JsonSerializerOptions(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var path = _env.WebRootPath + "/static-data/northwind-orders-type.json";
            if (!File.Exists(path))
            {
                return new List<OrdersType>();
            }
            var data = File.ReadAllText(path);
            return await Task.FromResult(JsonSerializer.Deserialize<List<OrdersType>>(data, options));
        }
    }
}
