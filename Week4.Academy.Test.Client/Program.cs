using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Week4.Academy.Test.Client.Methods;
using Week4.Academy.Test.Core.Models;

namespace Week4.Academy.Test.Client
{
    class Program
    {

        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            Console.WriteLine("Premi un tasto quando le API sono partite ...");
            Console.ReadLine();

            OrderMethods orderMethods = new OrderMethods(client);

            Order newOrder = new Order
            {
                ID_Customer = 1,
                Import = 7.34m,
                OrderCode = "OC-25012",
                ProductCode = "PC-042",
                OrderDate = new DateTime(2021, 04, 23)
            };

            await orderMethods.PostOrderAsync(newOrder);
            //await orderMethods.GetByIDOrderAsync(1);
            List<Order> orders = await orderMethods.FetchOrdersAsync();
            foreach (var item in orders)
            {
                Console.WriteLine(item);
            }
            //await orderMethods.DeleteOrderAsync(1);
            //await orderMethods.UpdateOrderAsync(2, newOrder);

            //Customer
            Console.Write("\nCustomer:\n");

            CustomerWCF.CustomerServiceClient customerClient = new CustomerWCF.CustomerServiceClient();
            customerClient.GetByIDCustomer(1);
            Customer newCustomer = new Customer()
            {
                CustomerCode = "CC-0212",
                FirstName = "Luca",
                LastName = "Di Pietro"
            };
            customerClient.AddCustomer(newCustomer);
            customerClient.DeleteByIdCustomer(2);
            newCustomer.FirstName = "Stefano";
            customerClient.UpdateCustomer(newCustomer);
            List<Customer> customers = customerClient.FetchCustomer();


        }
    }
}
