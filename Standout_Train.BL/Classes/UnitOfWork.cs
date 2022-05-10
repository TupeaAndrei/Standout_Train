using Standout_Train.BL.Interfaces;
using Standout_Train.DAL.AppRepository;
using Standout_Train.DAL.Context;
using Standout_Train.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.BL.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrainContext _context;

        public UnitOfWork(TrainContext context)
        {
            _context = context;
            Trains = new TrainRepository(_context);
        }
        public ITrainRepository Trains { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
