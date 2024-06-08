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
    public class MilkBrandRepository : GenericRepository<MilkBrand>, IMilkBrandRepository
    {
        public MilkBrandRepository(SWPDbContext context) : base(context)
        {      
        }

    }
}
