using MediatR;

namespace SWPApi.Application.Product.Commands
{
    public class AddProductCommand
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? AgeRange { get; set; }
        public Guid? MilkBrandId { get; set; }

    }
}
