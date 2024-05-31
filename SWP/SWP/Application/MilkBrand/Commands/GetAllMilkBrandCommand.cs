using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class GetAllMilkBrandCommand : IRequest<GetAllMilkBrandResponse>
    {
    }
}
