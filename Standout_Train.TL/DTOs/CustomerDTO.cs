using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.TL.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAdress { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
