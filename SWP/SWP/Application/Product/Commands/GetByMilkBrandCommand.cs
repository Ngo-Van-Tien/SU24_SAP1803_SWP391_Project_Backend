using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class GetByMilkBrandCommand : IRequest<GetByMilkBrandResponse>
    {
        public Guid Id { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
