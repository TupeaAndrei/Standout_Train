using Standout_Train.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Standout_Train.DAL.Models
{
    public class Customer : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(0,140)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAdress { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
