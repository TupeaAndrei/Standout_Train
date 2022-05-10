using Standout_Train.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Ticket>> GetBookedTickets(Customer customer);
        Task<List<Achievments>> GetUserAchievments(Customer customer);

    }
}
