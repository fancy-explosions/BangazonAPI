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
    public class TestPutEmployees
    {
        [Fact]
        public async Task Test_Modify_Employee()
        {
            string NewLastName = "Hibs";

            using (var client = new APIClientProvider().Client)
            {
                /*
                    ARRANGE
     [{"id":3,"departmentId":0,"firstName":"Single","lastName":"Quotes","isSupervisor":true,"trainingPrograms":[]},
                */
                Employee ModifiedJosh = new Employee
                {
                    DepartmentId = 1,
                    FirstName = "Josh",
                    LastName = NewLastName,
                    IsSupervisor = true
                };

                var ModifiedJoshAsJSON = JsonConvert.SerializeObject(ModifiedJosh);

                /*
                    ACT
                */
                var response = await client.PutAsync("/api/employees/1006",
                    new StringContent(ModifiedJoshAsJSON, Encoding.UTF8, "application/json")
                    );


                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
                /* getsection
                 */

                var getJosh = await client.GetAsync("/api/employees/1006");
                getJosh.EnsureSuccessStatusCode();

                string getJoshBody = await getJosh.Content.ReadAsStringAsync();
                Employee newJosh = JsonConvert.DeserializeObject<Employee>(getJoshBody);
            
                /*
                    ASSERT
                */
                Assert.Equal(HttpStatusCode.OK, getJosh.StatusCode);
                Assert.Equal(NewLastName, newJosh.LastName);

            }
        }
    }
}
