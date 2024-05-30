using Infrastructure.Entities;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class AddMilkBrandResponse : BaseResponse
    {
        public string Name { get; set; }
        
        public Guid? CompanyId { get; set; }
        public string? Description { get; set; }
    }
}
