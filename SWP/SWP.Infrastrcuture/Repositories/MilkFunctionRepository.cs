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
    public class MilkFunctionRepository : GenericRepository<MilkFunction>, IMilkFunctionRepository
    {
        public MilkFunctionRepository(SWPDbContext context) : base(context)
        {
        }
    }
}
