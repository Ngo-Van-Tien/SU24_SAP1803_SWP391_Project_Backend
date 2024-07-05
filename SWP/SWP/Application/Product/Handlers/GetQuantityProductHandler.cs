using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetQuantityProductHandler : IRequestHandler<GetQuantityProductCommand, GetQuantityProductResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetQuantityProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetQuantityProductResponse> Handle(GetQuantityProductCommand request, CancellationToken cancellationToken)
        {
            var response = new GetQuantityProductResponse();
            var products = _unitOfWork.ProductRepository.GetAll().ToList();
            var count = products.Count();
            response.Quantity = count;
            response.IsSuccess = true;
            return response;
        }
    }
}
