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
    public class TrainRepository : Repository<Train>, ITrainRepository
    {
        public TrainRepository(TrainContext context):base(context)
        {

        }
        public async Task<IEnumerable<Train>> GetAllTrainsThatStartFromCity(string city)
        {

            try
            {
                return await Task.Run(() => _context.Train.Where(t => t.DepartureCity.Equals(city)).ToList());
            }
            catch (DbUpdateException) { throw; }
        }

        public async Task<IEnumerable<Train>> GetAllTrainsThatStopInCity(string city)
        {
            try
            {
                return await Task.Run(() => _context.Train.Where(t => t.ArrivalCity.Equals(city)).ToList());
            }
            catch (DbUpdateException) { throw; }
        }
    }
}
