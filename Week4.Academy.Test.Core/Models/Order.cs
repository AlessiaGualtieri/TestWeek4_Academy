using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Academy.Test.Core.Models
{
    public class Order
    {
        public int ID_Order { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Import { get; set; }

        public Customer Customer { get; set; }
        public int ID_Customer { get; set; }
    }
}
