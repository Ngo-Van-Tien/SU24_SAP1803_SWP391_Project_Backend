using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class GetMilkFunctionsCommand : IRequest<GetMilkFunctionsResponse>
    { 
        public Guid Id { get; set; }
    }
}
