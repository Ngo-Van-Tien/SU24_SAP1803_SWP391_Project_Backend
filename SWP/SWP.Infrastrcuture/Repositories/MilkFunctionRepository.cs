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
    public class MilkFunctionRepository : GenericRepository<MilkFunction>, IMilkFunctionRepository
    {
        public MilkFunctionRepository(SWPDbContext context) : base(context)
        {
        }

        public async Task AddMilkFunciton(MilkFunction milkFunction)
        {
            await _context.Set<MilkFunction>().AddAsync(milkFunction);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteMilkFunction(MilkFunction milkFunction)
        {
            _context.Set<MilkFunction>().Remove(milkFunction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MilkFunction>> GetAllMilkFunction()
        {
            return await _context.Set<MilkFunction>().ToListAsync();
        }

        public async Task UpdateMilkFunction(MilkFunction milkFunction)
        {
            _context.Set<MilkFunction>().Update(milkFunction);
            await _context.SaveChangesAsync();
        }

        public async Task<MilkFunction> GetById(Guid id)
        {
             return await _context.Set<MilkFunction>().FindAsync(id);
        }
    }
}
