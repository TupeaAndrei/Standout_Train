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
    public class Train : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public double RouteDistance { get; set; }
        [Required]
        [ForeignKey("Society")]
        public int SocietyId { get; set; }
    }
}
