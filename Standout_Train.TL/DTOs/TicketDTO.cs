using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.TL.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public DateTime AqquiredAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsExpired { get; set; }
        public int CustomerId { get; set; }
        public int TrainId { get; set; }

    }
}
