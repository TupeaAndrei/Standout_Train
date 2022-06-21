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
    public class Report : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }  
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}
