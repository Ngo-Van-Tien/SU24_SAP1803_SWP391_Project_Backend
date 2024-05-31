using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class AddProductCommand: IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? AgeRange { get; set; }
        public Guid? MilkBrandId { get; set; }

    }
}
