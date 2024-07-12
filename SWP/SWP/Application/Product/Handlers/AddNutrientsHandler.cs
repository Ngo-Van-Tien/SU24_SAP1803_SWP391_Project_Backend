using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class AddNutrientsHandler : IRequestHandler<AddNutrientsCommand, AddNutrientsResponse>
    {
        IUnitOfWork _unitOfWork;
        public AddNutrientsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AddNutrientsResponse> Handle(AddNutrientsCommand request, CancellationToken cancellationToken)
        {
            var response = new AddNutrientsResponse();
            
            var product = _unitOfWork.ProductRepository.GetById(request.Id);
            if(product == null || !product.Enable)
            {
                response.ErrorMessage = "Product is not existed";
                return response;
            }
            var productNutrients = new List<ProductNutrient>();
            var nutrientDetails = request.Nutrients;
            
            if (nutrientDetails.Any())
            {
                foreach(var n in nutrientDetails)
                {
                    var nutrientDetail = _unitOfWork.NutrientRepository.GetById(n.Id);
                    if(nutrientDetail != null && nutrientDetail.Enable)
                    {
                        var productNutrient = new ProductNutrient
                        {
                            Nutrient = nutrientDetail,
                            Product = product,
                            In100g = n.In100g,
                            InCup = n.InCup,
                            Unit = n.Unit,
                        };
                        productNutrients.Add(productNutrient);
                    }  
                }
            }

            _unitOfWork.ProductNutrientRepository.AddRange(productNutrients);
            await _unitOfWork.SaveChangesAsync();
            response.IsSuccess = true;
            return response;

        }
    }
}
