using Infrastructure.Entities;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class GetAllMilkBrandResponse : BaseResponse
    {
        public List<Infrastructure.Entities.MilkBrand> MilkBrands { get; set; }

        public GetAllMilkBrandResponse(List<Infrastructure.Entities.MilkBrand> milkBrands)
        {
            MilkBrands = milkBrands;
        }
    }
}
