﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task<Product> GetById(Guid Id);
        Task DeleteProduct(Product product);
    }
}
