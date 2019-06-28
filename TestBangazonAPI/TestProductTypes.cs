using System.Net;
using Newtonsoft.Json;
using Xunit;
using BangazonAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TestBangazonAPI
{
    public class TestProductTypes
    {
        [Fact]
        public async Task Test_Get_All_ProductTypes()
        {
            using (var client = new APIClientProvider().Client)
            {
                var response = await client.GetAsync("/api/ProductType");

                string responseBody = await response.Content.ReadAsStringAsync();
                var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(responseBody);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(productTypes.Count > 0);
            }
        }
        [Fact]
        public async Task Test_Get_Single_ProductType()
        {
            using (var client = new APIClientProvider().Client)
            {
                var response = await client.GetAsync("/api/ProductType/1");

                string responseBody = await response.Content.ReadAsStringAsync();
                var productTypes = JsonConvert.DeserializeObject<ProductType>(responseBody);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(productTypes != null);
            }
        }
        [Fact]
        public async Task Test_Post_Single_ProductType()
        {
            using (var client = new APIClientProvider().Client)
            {
                ProductType toys = new ProductType
                {
                    Name = "Toys"
                };
                var toysAsJSON = JsonConvert.SerializeObject(toys);

                var response = await client.PostAsync(
                    "api/ProductType",
                    new StringContent(toysAsJSON, Encoding.UTF8, "application/json")
                    );

                string responseBody = await response.Content.ReadAsStringAsync();

                var newToy = JsonConvert.DeserializeObject<ProductType>(responseBody);

                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
                Assert.Equal("Toys", newToy.Name);

            }
        }
        [Fact]
        public async Task Test_Put_ProductType()
        {
            string newTypeName = "Appliances";
            using (var client = new APIClientProvider().Client)
            {
                ProductType newPType = new ProductType
                {
                    Name = newTypeName
                };

                var newTypeNameJSON = JsonConvert.SerializeObject(newPType);

                var response = await client.PutAsync(
                    "/api/ProductType/1",
                    new StringContent(newTypeNameJSON, Encoding.UTF8, "application/json")
                    );
                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                //GET Section to verify

                var getNewType = await client.GetAsync("/api/ProductType/1");
                getNewType.EnsureSuccessStatusCode();

                string getNewTypeBody = await getNewType.Content.ReadAsStringAsync();
                ProductType newType = JsonConvert.DeserializeObject<ProductType>(getNewTypeBody);

                Assert.Equal(HttpStatusCode.OK, getNewType.StatusCode);
                Assert.Equal(newTypeName, newPType.Name); 

            }
        }
    }
}
