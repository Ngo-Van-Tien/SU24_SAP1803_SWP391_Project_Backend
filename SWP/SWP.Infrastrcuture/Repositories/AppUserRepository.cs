using Infrastructure.IRepositories;
using SWP.Infrastrcuture;
using SWP.Infrastrcuture.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(SWPDbContext context) : base(context)
        {
        }
    }
}
