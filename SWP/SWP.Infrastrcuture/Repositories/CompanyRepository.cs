using Infrastructure.Entities;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using SWP.Infrastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SWPDbContext context) : base(context) 
        {
        }

        public async Task AddCompany(Company company)
        {
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompany(Company company)
        {
            _context.Set<Company>().Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await _context.Set<Company>().ToListAsync();
            
        }

        public async Task<Company> GetById(Guid id)
        {
            return await _context.Set<Company>().FindAsync(id);
        }

        public async Task UpdateCompany(Company company)
        {
             _context.Set<Company>().Update(company);
            await _context.SaveChangesAsync();
        }
    }
}
