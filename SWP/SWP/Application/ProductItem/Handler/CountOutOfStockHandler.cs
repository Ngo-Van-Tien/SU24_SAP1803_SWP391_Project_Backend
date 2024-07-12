using Infrastructure;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;
using System.Collections;

namespace SWPApi.Application.ProductItem.Handler
{
    public class CountOutOfStockHandler : IRequestHandler<CountOutOfStockCommand, CountOutOfStockResponse>
    {
        IUnitOfWork _unitOfWork;

        public CountOutOfStockHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CountOutOfStockResponse> Handle(CountOutOfStockCommand request, CancellationToken cancellationToken)
        {
            var productItemsOutOfStock = _unitOfWork.ProductItemRepository.GetAll()
                                       .Where(item => item.Quantity == 0 && item.Enable)
                                       .Count();

            var response = new CountOutOfStockResponse
            {
                IsSuccess = true,
                Quantity = productItemsOutOfStock
            };

            return response;
        }
    }
}
