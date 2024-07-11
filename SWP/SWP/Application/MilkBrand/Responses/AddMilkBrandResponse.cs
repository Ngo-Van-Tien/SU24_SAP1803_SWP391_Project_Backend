using Infrastructure.Entities;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class AddMilkBrandResponse : BaseResponse
    {
        public Infrastructure.Entities.MilkBrand MilkBrand { get; set; }
    }
}
