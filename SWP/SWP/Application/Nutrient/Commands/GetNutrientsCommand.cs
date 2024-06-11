using MediatR;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Commands
{
    public class GetNutrientsCommand : IRequest<GetNutrientsResponse>
    {
    }
}
