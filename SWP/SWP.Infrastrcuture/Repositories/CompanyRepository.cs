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
    }
}
