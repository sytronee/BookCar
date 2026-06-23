using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public Car car { get; set; }
        public int PricingID { get; set; }
        public Decimal Amount { get; set; }
    }
}
