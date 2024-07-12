using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class UpdateMilkFunctionsCommand : IRequest<UpdateMilkFunctionsResponse>
    {
        public Guid Id { get; set; }
        public Guid MilkFunctionId { get; set; }
    }
}
