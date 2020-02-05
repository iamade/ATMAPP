using System.Collections.Generic;
using System.Threading.Tasks;
using AtmApp.API.Models;

namespace AtmApp.API.Data
{
    public interface IFaultLogRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<FaultLog>> GetFaultLogs();
         Task<FaultLog> GetFaultLog(int id);
    }
}