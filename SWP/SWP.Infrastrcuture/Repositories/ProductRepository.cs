using Infrastructure.Entities;
using Infrastructure.IRepositories;
using PagedList;
using SWP.Infrastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SWPDbContext context) : base(context)
        {

        }

        
    }
}
