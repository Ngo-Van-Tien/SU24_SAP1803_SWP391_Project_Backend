using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class CountProductItemHandler : IRequestHandler<CountProductItemCommand, CountProductItemResponse>
    {
        IUnitOfWork _unitOfWork;
        public CountProductItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CountProductItemResponse> Handle(CountProductItemCommand request, CancellationToken cancellationToken)
        {
            var productItems = _unitOfWork.ProductItemRepository.GetAll().ToList();
            var count = productItems.Count();
            var response = new CountProductItemResponse();
            response.Quantity = count;
            response.IsSuccess = true;
            return response;
        }
    }
}
