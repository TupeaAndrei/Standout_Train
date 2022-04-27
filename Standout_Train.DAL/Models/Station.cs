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
    public class Station : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [ForeignKey("County")]
        public int CountyId { get; set; }
    }
}
