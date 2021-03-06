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
    public class Ticket : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime AqquiredAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsExpired { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("Train")]
        public int TrainId { get; set; }
    }
}
