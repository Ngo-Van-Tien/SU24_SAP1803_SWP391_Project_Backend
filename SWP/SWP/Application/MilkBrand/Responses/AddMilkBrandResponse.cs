using Infrastructure.Entities;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.MilkBrand.Responses
{
    public class AddMilkBrandResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Infrastructure.Entities.Image Company { get; set; }
        public string? Description { get; set; }
    }
}
