using Infrastructure.Models;

namespace SWPApi.Application.Product.Responses
{
    public class GetProductResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        public string ImageBase64 { get; set; }
        public Infrastructure.Entities.MilkBrand MilkBrand { get; set; }
    }
}
