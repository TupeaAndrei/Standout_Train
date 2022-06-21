using Standout_Train.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAchievmentRepository Achievments { get; }
        ICountyRepository County { get; }
        ISocietyRepository Society { get; }
        IStationRepository Stations { get; }
        ITicketRepository Tickets { get; }
        ITrainStationRepository TrainStations { get; }
        ITrainRepository Trains { get; }
        ICustomerRepository Customers { get; }
        IReportRepository Reports { get; }
        Task<int> Complete();
    }
}
