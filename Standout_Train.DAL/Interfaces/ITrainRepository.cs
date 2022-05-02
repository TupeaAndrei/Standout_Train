using Standout_Train.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.Interfaces
{
    public interface ITrainRepository : IRepository<Train>
    {
        Task<IEnumerable<Train>> GetAllTrainsThatStartFromCity(string city);
        Task<IEnumerable<Train>> GetAllTrainsThatStopInCity(string city);
    }
}
