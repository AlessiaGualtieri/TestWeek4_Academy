using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Week4.Academy.Test.Client.Contracts;
using Week4.Academy.Test.Client.Methods;

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

            OrderContract newOrder = new OrderContract
            {
                ID_Customer = 1,
                Import = 7.34m,
                OrderCode = "OC-25012",
                ProductCode = "PC-042",
                OrderDate = new DateTime(2021, 04, 23)
            };

            //await orderMethods.PostOrderAsync(newOrder);
            await orderMethods.GetByIDOrderAsync(1);
            await orderMethods.FetchOrdersAsync();

            //Customer
            Console.Write("\nCustomer:\n");
            CustomerWCF.CustomerServiceClient customerClient = new CustomerWCF.CustomerServiceClient();
            customerClient.GetByIDCustomer(1);
            customerClient.FetchCustomer();



        }
    }
}
