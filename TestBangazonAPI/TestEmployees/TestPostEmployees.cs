using System;
using System.Net;
using Newtonsoft.Json;
using Xunit;
using BangazonAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace TestBangazonAPI.TestEmployees
{
    public class TestPostEmployees
    {
        [Fact]
        public async Task Test_Create_Employee()
        {
            using (var client = new APIClientProvider().Client)
            {
                /*
                    ARRANGE
     [{"id":3,"departmentId":0,"firstName":"Single","lastName":"Quotes","isSupervisor":true,"trainingPrograms":[]},
                */
                Employee Josh = new Employee
                {
                    DepartmentId = 1,
                    FirstName = "Josh",
                    LastName = "Hibray",
                    IsSupervisor = true
                };

                var JoshAsJSON = JsonConvert.SerializeObject(Josh);

                /*
                    ACT
                */
                var response = await client.PostAsync("/api/employees",
                    new StringContent(JoshAsJSON, Encoding.UTF8, "application/json")
                    );


                string responseBody = await response.Content.ReadAsStringAsync();
                var newJosh = JsonConvert.DeserializeObject<Employee>(responseBody);

                /*
                    ASSERT
                */
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
                Assert.Equal(1, newJosh.DepartmentId);
                Assert.Equal("Josh", newJosh.FirstName);
                Assert.Equal("Hibray", newJosh.LastName);
                Assert.True(newJosh.IsSupervisor);

            }
        }
    }
}

