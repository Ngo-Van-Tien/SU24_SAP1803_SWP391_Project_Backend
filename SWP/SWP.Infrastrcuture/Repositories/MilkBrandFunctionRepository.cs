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
    public class MilkBrandFunctionRepository : GenericRepository<MilkBrandFunction>, IMilkBrandFunctionRepository
    {
        public MilkBrandFunctionRepository(SWPDbContext context) : base(context)
        {
        }
    }
}
