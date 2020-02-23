using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace shopApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; } //om inlogg finns kan samma kund göra flera ordrar.
    }
}