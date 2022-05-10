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
        ITrainRepository Trains { get; }
        Task<int> Complete();
    }
}
