using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonAPI.Models
{
    public class PaymentType
    {
        public int Id { get; set; }

        [Required]
        private int AccountNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public void addAccountNumber(int num)
        {
            AccountNumber = num;
        }
    }
}
