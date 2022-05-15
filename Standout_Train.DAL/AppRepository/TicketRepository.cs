using Standout_Train.DAL.Context;
using Standout_Train.DAL.Interfaces;
using Standout_Train.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.AppRepository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(TrainContext context) : base(context)
        {
        }
    }
}
