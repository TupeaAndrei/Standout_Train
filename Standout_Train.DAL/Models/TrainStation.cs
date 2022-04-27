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
    public class TrainStation : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Station")]
        public int StationId { get; set; }
        [Required]
        [ForeignKey("Train")]
        public int TrainId { get; set; }
    }
}
