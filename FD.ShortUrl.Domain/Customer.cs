using System.Collections.Generic;

namespace FD.ShortUrl.Domain
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
