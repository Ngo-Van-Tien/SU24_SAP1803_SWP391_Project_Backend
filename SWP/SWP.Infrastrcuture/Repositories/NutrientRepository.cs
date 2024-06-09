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
    public class NutrientRepository : GenericRepository<Nutrient>, INutrientRepository
    {
        public NutrientRepository(SWPDbContext context) : base(context)
        {
        }
        
    }
}
