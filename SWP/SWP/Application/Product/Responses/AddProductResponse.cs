using Infrastructure.Models;

namespace SWPApi.Application.Product.Responses
{
    public class AddProductResponse: BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? AgeRange { get; set; }
        public Guid? MilkBrandId { get; set; }
    }
}
