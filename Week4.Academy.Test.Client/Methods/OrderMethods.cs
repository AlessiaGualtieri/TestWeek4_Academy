using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Week4.Academy.Test.Core.Models;

namespace Week4.Academy.Test.Client.Methods
{
    class OrderMethods
    {
        private readonly HttpClient client;

        public OrderMethods(HttpClient client)
        {
            this.client = client;
        }

        public async Task<bool> PostOrderAsync(Order newOrder)
        {
            HttpRequestMessage postRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44328/api/orders")
            };

            string newBookJson = JsonConvert.SerializeObject(newOrder);
            postRequest.Content = new StringContent(newBookJson,
                Encoding.UTF8, "application/json");

            HttpResponseMessage postResponse = await client.SendAsync(postRequest);

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = await postResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Order>(data);

                Console.WriteLine($"Order added with id = {result.ID_Order}");
                return true;
            }
            return false;
        }

        public async Task<List<Order>> FetchOrdersAsync()
        {
            HttpRequestMessage postRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44328/api/orders")
            };

            HttpResponseMessage postResponse = await client.SendAsync(postRequest);

            if (postResponse.IsSuccessStatusCode)
            {
                string data = await postResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Order>>(data);

                return result;
            }
            return null;
        }

        public async Task<Order> GetByIDOrderAsync(int id)
        {
            Order result = null;
            if (id <= 0)
                return null;

            HttpRequestMessage postRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44328/api/orders/{id}")
            };

            HttpResponseMessage postResponse = await client.SendAsync(postRequest);

            if (postResponse.IsSuccessStatusCode)
            {
                string data = await postResponse.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Order>(data);
            }
            return result;
        }

        public async Task<bool> UpdateOrderAsync(int id, Order newOrder)
        {
            HttpRequestMessage putRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://localhost:44376/api/books/{id}")
            };

            string newOrderJSON = JsonConvert.SerializeObject(newOrder);
            putRequest.Content = new StringContent(newOrderJSON,
                Encoding.UTF8, "application/json");

            HttpResponseMessage putResponse = await client.SendAsync(putRequest);

            if (putResponse.IsSuccessStatusCode)
            {
                string data = await putResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Order>(data);

                Console.WriteLine("Successfully updated order");
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            HttpRequestMessage deleteRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:44376/api/books/{id}")
            };


            HttpResponseMessage deleteResponse = await client.SendAsync(deleteRequest);

            if (deleteResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"Order deleted with id = {id}");
                return true;
            }
            return false;
        }
    }
}
