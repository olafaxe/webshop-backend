using System.Collections.Generic;

namespace shopApi.Models
{
    public class OrderViewModel
    {
        public List<ProductViewModel> Cart { get; set; }
        public CustomerViewModel Customer { get; set; }
    }
}