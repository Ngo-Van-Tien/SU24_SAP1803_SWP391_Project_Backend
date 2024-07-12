using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class DeleteNutrientsHandler : IRequestHandler<DeleteNutrientsCommand, DeleteNutrientsResponse>
    {
        IUnitOfWork _unitOfWork;
        public DeleteNutrientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteNutrientsResponse> Handle(DeleteNutrientsCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteNutrientsResponse();
            var product = _unitOfWork.ProductRepository.GetById(request.Id);
            if (product == null || !product.Enable)
            {
                response.ErrorMessage = "Product is not existed";
                return response;
            }

            var productNutrient = _unitOfWork.ProductNutrientRepository.Find(x => x.Product.Id == request.Id && x.Nutrient.Id == request.NutrientId);
            if(productNutrient != null)
            {
                _unitOfWork.ProductNutrientRepository.RemoveRange(productNutrient);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
            }
            return response;
        }
    }
}
