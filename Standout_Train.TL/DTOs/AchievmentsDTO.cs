using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.TL.DTOs
{
    public class AchievmentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AquiredDate { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
    }
}
