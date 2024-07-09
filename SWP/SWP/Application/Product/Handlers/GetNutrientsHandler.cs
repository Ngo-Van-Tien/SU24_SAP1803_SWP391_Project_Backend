using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetNutrientsHandler : IRequestHandler<GetNutrientsCommand, GetNutrientsResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetNutrientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetNutrientsResponse> Handle(GetNutrientsCommand request, CancellationToken cancellationToken)
        {
            var response = new GetNutrientsResponse();
            var nutrients = _unitOfWork.ProductNutrientRepository.Find(pn => pn.Product.Id == request.Id)
                                                                 .Select(pn => pn.Nutrient)
                                                                 .ToList();
            if(nutrients.Any() && nutrients != null)
            {
                response.Data = nutrients;
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "No milk functions found for the specified milk brand.";
            }
            return response;
        }
    }
}
