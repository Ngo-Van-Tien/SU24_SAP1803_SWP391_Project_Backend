using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class DeleteMilkBrandCommand : IRequest<DeleteMilkBrandResponse>
    {
        public Guid Id { get; set; }
    }
}
