using Microsoft.EntityFrameworkCore;
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
    public class CustomerRepository : Repository<Customer> ,ICustomerRepository
    {
        public CustomerRepository(TrainContext context):base(context)
        {

        }
        public async Task<List<Ticket>> GetBookedTickets(Customer customer)
        {
            try
            {
                return await Task.Run(() => _context.Ticket.Join(_context.Customer,
                    t => t.CustomerId,
                    c => c.Id,
                    (t, c) => new { customer = c, ticket = t })
                    .Where(ct => ct.ticket.CustomerId == customer.Id && ct.customer.Id == customer.Id)
                    .Select(ct => ct.ticket).ToList());
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task<List<Achievments>> GetUserAchievments(Customer customer)
        {
            try
            {
                return await Task.Run(() => _context.Achievment.Join(_context.Customer,
                    a => a.CustomerId,
                    c => c.Id,
                    (a, c) => new { customer = c, achievment = a })
                    .Where(ac => ac.achievment.CustomerId == customer.Id && ac.customer.Id == customer.Id)
                    .Select(ac => ac.achievment).ToList());
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
