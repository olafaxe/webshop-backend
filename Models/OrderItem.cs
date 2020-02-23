using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shopApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Price { get; set; }
        public int SizeId { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
    }
}