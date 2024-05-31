using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IMilkBrandRepository : IGenericRepository<MilkBrand>
    {
        Task AddMilkBrand(MilkBrand milkBrand);
        Task UpdateMilkBrand(MilkBrand milkBrand);
        Task<MilkBrand> GetById(Guid Id);
        Task DeleteMilkBrand(MilkBrand milkBrand);
        Task<IEnumerable<MilkBrand>> GetAllMilkBrands();
    }
}
