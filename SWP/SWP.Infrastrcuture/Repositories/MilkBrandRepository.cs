using Infrastructure.Entities;
using Infrastructure.IRepositories;
using SWP.Infrastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MilkBrandRepository : GenericRepository<MilkBrand>, IMilkBrandRepository
    {
        public MilkBrandRepository(SWPDbContext context) : base(context)
        {      
        }
        public async Task AddMilkBrand(MilkBrand milkBrand)
        {
            await _context.Set<MilkBrand>().AddAsync(milkBrand);
            await _context.SaveChangesAsync();
        }
    }
}
