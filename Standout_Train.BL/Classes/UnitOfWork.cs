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
            Customers = new CustomerRepository(_context);
            Achievments = new AchievmentRepository(_context);
            County = new CountyRepository(_context);
            Society = new SocietyRepository(_context);
            Stations = new StationRepository(_context);
            Tickets = new TicketRepository(_context);
            TrainStations = new TrainStationRepository(_context);
            Reports  = new ReportRepository(_context);
        }
        public IAchievmentRepository Achievments { get; private set; }
        public ICountyRepository County { get; private set; }
        public ISocietyRepository Society { get; private set; }
        public IStationRepository Stations { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public ITrainStationRepository TrainStations { get; private set; }
        public ITrainRepository Trains { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IReportRepository Reports { get; private set; }

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
