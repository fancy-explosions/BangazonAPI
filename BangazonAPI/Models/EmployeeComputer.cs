using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonAPI.Models
{
    public class EmployeeComputer
    {
        public int Id { get; set; }

        [Required]
        public DateTime Assign { get; set; }

        
        public DateTime Unassign { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ComputerId { get; set; }

        public Dictionary<Employee, Computer> EmployeesComputer { get; set; } = new Dictionary<Employee, Computer>();

    }
}
