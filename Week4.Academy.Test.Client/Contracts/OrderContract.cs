using System;
using System.Collections.Generic;
using System.Text;

namespace Week4.Academy.Test.Client.Contracts
{
    public class OrderContract
    {
        public int ID_Order { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderCode { get; set; }
        public string ProductCode { get; set; }
        public decimal Import { get; set; }

        public int ID_Customer { get; set; }

        public override string ToString()
        {
            return $"{ID_Order} - Order code: {OrderCode} - Product code: " +
                $"{ProductCode} - Date: {OrderDate} - Import: {Import} - " +
                $"ID Costumer: {ID_Customer}";
        }
    }
}
