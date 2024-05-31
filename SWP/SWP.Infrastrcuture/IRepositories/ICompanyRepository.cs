﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task AddCompany(Company company);
        Task<Company> GetById(Guid id);
        Task UpdateCompany(Company company);
        Task DeleteCompany(Company company);
        Task<IEnumerable<Company>> GetAllCompany();
        
    }
}
