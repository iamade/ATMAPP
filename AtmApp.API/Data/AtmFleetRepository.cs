using System.Collections.Generic;
using System.Threading.Tasks;
using AtmApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApp.API.Data
{
    public class AtmFleetRepository : IAtmFleetRepository
    {
        private readonly DataContext _context;
        public AtmFleetRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<bool> AtmExists(string terminalId)
        {
            if (await _context.AtmFleet.AnyAsync(x => x.TerminalId == terminalId))
                return true;
            return false;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<AtmFleet> GetAtm(int id)
        {
            var atm = await _context.AtmFleet.FirstOrDefaultAsync(u => u.Id == id);

            return atm;
        }

        public async Task<IEnumerable<AtmFleet>> GetAtms()
        {
            var atms = await _context.AtmFleet.ToListAsync();

            return atms;

        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}