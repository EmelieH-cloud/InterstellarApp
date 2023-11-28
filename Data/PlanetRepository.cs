using InterstellarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InterstellarApp.Data
{
    public class PlanetRepository
    {
        private readonly MyDbContext _context;

        public PlanetRepository(MyDbContext context)
        {
            _context = context;
        }

        // FIND ALL
        public async Task<List<Planet>> GetAllAsync()
        {
            return await _context.Planets.ToListAsync();
        }

        public async Task RemovePlanetAsync(int id)
        {
            Planet? planetToDelete = await GetByIdAsync(id);
            if (planetToDelete != null)
            {
                _context.Planets.Remove(planetToDelete);
            }
        }

        // FIND BY ID
        public async Task<Planet?> GetByIdAsync(int id)
        {
            return await _context.Planets.FirstOrDefaultAsync(p => p.Id == id);
        }

        // ADD
        public async Task AddPlanetAsync(Planet p)
        {
            await _context.Planets.AddAsync(p);
        }

        // UPDATE
        public async Task UpdateAsync(int id, Planet p)
        {
            Planet? planetToUpdate = await _context.Planets.FirstOrDefaultAsync(p => p.Id == id);

            if (planetToUpdate != null)
            {
                planetToUpdate.Name = p.Name;
                planetToUpdate.Description = p.Description;


            }
        }
    }
}
