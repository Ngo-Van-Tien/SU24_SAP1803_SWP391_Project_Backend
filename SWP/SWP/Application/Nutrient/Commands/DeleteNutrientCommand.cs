using MediatR;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Commands
{
    public class DeleteNutrientCommand : IRequest<DeleteNutrientResponse>
    {
        public Guid Id { get; set; }
    }
}
