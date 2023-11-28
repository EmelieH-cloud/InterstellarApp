using InterstellarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterstellarApp.Data
{
    public class VisitorRepository
    {
        private readonly MyDbContext _context;

        public VisitorRepository(MyDbContext context)
        {
            _context = context;
        }

        // FIND ALL
        public async Task<List<Visitor>> GetAllAsync()
        {
            return await _context.Visitors.ToListAsync();
        }

        // FIND BY ID
        public async Task<Visitor?> GetByIdAsync(int id)
        {
            return await _context.Visitors.FirstOrDefaultAsync(v => v.Id == id);
        }

        // ADD
        public async Task AddVisitorAsync(Visitor v)
        {
            await _context.Visitors.AddAsync(v);
        }

        public async Task RemoveVisitorAsync(int id)
        {
            Visitor? visitorToDelete = await GetByIdAsync(id);
            if (visitorToDelete != null)
            {
                _context.Visitors.Remove(visitorToDelete);
            }
        }

        // UPDATE
        public async Task UpdateAsync(int id, Visitor v)
        {
            Visitor? visitorToUpdate = await _context.Visitors.FirstOrDefaultAsync(v => v.Id == id);

            if (visitorToUpdate != null)
            {
                visitorToUpdate.Name = v.Name;

                // No need to save changes here; it will be done at the calling level.
            }
        }
    }

}
