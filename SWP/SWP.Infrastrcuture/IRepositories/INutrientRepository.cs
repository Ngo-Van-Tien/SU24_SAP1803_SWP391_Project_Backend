using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface INutrientRepository
    {
        Task AddNutrient(Nutrient nutrient);
        Task<Nutrient> GetById(Guid id);
        Task<IEnumerable<Nutrient>> GetAllNutrient();
        Task UpdateNutrient(Nutrient nutrient);
        Task DeleteNutrient(Nutrient nutrient);
    }
}
