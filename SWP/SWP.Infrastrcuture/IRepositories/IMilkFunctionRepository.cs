using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IMilkFunctionRepository
    {
        Task AddMilkFunciton(MilkFunction milkFunction);
        Task<MilkFunction> GetById(Guid id);
        Task<IEnumerable<MilkFunction>> GetAllMilkFunction();
        Task UpdateMilkFunction(MilkFunction milkFunction);
        Task DeleteMilkFunction(MilkFunction milkFunction);
    }
}
