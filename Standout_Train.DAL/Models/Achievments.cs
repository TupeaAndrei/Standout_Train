using Standout_Train.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.Models
{
    public class Achievments : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime AquiredDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}
