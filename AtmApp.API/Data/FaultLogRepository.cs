using System.Collections.Generic;
using System.Threading.Tasks;
using AtmApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApp.API.Data
{
    public class FaultLogRepository : IFaultLogRepository
    {
        private readonly DataContext _context;
        public FaultLogRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public async Task<FaultLog> GetFaultLog(int id)
        {
           var faultLog = await _context.FaultLogs.FirstOrDefaultAsync(u => u.Id == id);

            return faultLog;
        }

        public async Task<IEnumerable<FaultLog>> GetFaultLogs()
        {
            var faultLogs = await _context.FaultLogs.ToListAsync();

            return faultLogs;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}