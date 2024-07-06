using MediatR;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Commands
{
    public class GetNutrientsCommand : IRequest<GetNutrientsResponse>
    {
        public Guid Id { get; set; }
    }
}
