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
    public class ProductNutrientRepository : GenericRepository<ProductNutrient>, IProductNutrientRepository
    {
        public ProductNutrientRepository(SWPDbContext context) : base(context)
        {
        }
    }
}
