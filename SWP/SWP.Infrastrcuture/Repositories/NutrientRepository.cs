using Infrastructure.Entities;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using SWP.Infrastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NutrientRepository : GenericRepository<Nutrient>, INutrientRepository
    {
        public NutrientRepository(SWPDbContext context) : base(context)
        {
        }

        public async Task AddNutrient(Nutrient nutrient)
        {
            await _context.Set<Nutrient>().AddAsync(nutrient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNutrient(Nutrient nutrient)
        {
            _context.Set<Nutrient>().Remove(nutrient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNutrient(Nutrient nutrient)
        {
            _context.Set<Nutrient>().Update(nutrient);
            await _context.SaveChangesAsync();
        }

        public async Task<Nutrient> GetById(Guid id)
        {
            return await _context.Set<Nutrient>().FindAsync(id);
        }

        public async Task<IEnumerable<Nutrient>> GetAllNutrient()
        {
            return await _context.Set<Nutrient>().ToListAsync();
        }
    }
}
