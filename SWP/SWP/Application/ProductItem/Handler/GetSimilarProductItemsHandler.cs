using Infrastructure;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class GetSimilarProductItemsHandler : IRequestHandler<GetSimilarProductItemsCommand, GetSimilarProductItemsResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetSimilarProductItemsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSimilarProductItemsResponse> Handle(GetSimilarProductItemsCommand request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.ProductRepository.GetById(request.ProductId);
            var response = new GetSimilarProductItemsResponse();    
            if (product == null || !product.Enable) 
            {
                response.ErrorMessage = "Product is not found";
                return response;
            }
            var productItems = _unitOfWork.ProductItemRepository.Find(pi => pi.Product.Id == request.ProductId && pi.Id != request.Id).ToList();
            if(productItems.Any())
            {
                response.Data = productItems;
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "Do not have any similars product";
            }
            return response;
        }
    }
}
