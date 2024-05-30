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

        public async Task UpdateMilkBrand(MilkBrand milkBrand)
        {
            _context.Set<MilkBrand>().Update(milkBrand);
            await _context.SaveChangesAsync();
        }

        public async Task<MilkBrand> GetById(Guid Id)
        {
            return await _context.Set<MilkBrand>().FindAsync(Id);
        }

        public async Task DeleteMilkBrand(MilkBrand milkBrand)
        {
            _context.Set<MilkBrand>().Remove(milkBrand);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistMilkBrand(Guid Id)
        {
            bool checkExist = false;
            var milkBrand = await _context.MilkBrands.FindAsync(Id);
            if(milkBrand != null)
            {
                checkExist = true;
            }
            return checkExist;
        }
    }
}
