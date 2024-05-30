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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SWPDbContext context) : base(context)
        {
            
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChangesAsync();
        }

    }
}
