using Newtonsoft.Json;
using BangazonAPI.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace TestBangazonAPI.TestEmployees
{
    public class TestGetOneEmployee
    {
        [Fact]
        public async Task Test_Get_Single_Employee()
        {

            using (var client = new APIClientProvider().Client)
            {
                var response = await client.GetAsync("api/employees/1009");


                string responseBody = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<Employee>(responseBody);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(0, employee.DepartmentId);
                Assert.Equal("Josh", employee.FirstName);
                Assert.Equal("Hibray", employee.LastName);
                Assert.True(employee.IsSupervisor);
                Assert.NotNull(employee);
            }
        }
    }
}
