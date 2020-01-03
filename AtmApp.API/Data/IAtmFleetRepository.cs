using System.Collections.Generic;
using System.Threading.Tasks;
using AtmApp.API.Models;

namespace AtmApp.API.Data
{
    public interface IAtmFleetRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<AtmFleet>> GetAtms();
         Task<AtmFleet> GetAtm(int id);
         Task<bool> AtmExists(string terminalId);
        
         
    }
}