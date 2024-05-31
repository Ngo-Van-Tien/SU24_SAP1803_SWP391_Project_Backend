using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class AddProductCommand: IRequest<AddProductResponse>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string AgeRange {  get; set; }
    }
}
