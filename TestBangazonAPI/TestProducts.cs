using System;
using System.Net;
using Newtonsoft.Json;
using Xunit;
using BangazonAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestBangazonAPI
{
    public class TestProducts
    {
        [Fact]
        public async Task Test_Get_All_Products()
        {
            using (var client = new APIClientProvider().Client)
            {
                var response = await client.GetAsync("/api/products");

                string responseBody = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(products.Count > 0);
            }
        }
        [Fact]
        public async Task Test_Get_Single_Product()
        {
            using (var client = new APIClientProvider().Client)
                {
                var response = await client.GetAsync("api/products/5");

                string responseBody = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(responseBody);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal("iPhone", product.Title);
                Assert.Equal("A steal!", product.Description);
                Assert.NotNull(product);

            }
        }
    }
}