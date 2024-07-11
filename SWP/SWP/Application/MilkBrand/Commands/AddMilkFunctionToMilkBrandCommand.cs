using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class AddMilkFunctionToMilkBrandCommand : IRequest<AddMilkFunctionToMilkBrandResponse>
    {
        public Guid Id { get; set; }
        public List<Guid> MilkFunctionIds { get; set; } = new List<Guid>();
    }
}
