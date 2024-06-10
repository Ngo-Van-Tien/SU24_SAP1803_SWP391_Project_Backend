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

        
    }
}
