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
            var productItems = _unitOfWork.ProductItemRepository.GetAll().ToList();
            var productItemsOutOfStock = new ArrayList();
            foreach (var item in productItems)
            {
                if(item.Quantity == 0)
                {
                    productItemsOutOfStock.Add(item);
                }
            }

            var response = new CountOutOfStockResponse();
            response.IsSuccess = true;
            response.Quantity = productItemsOutOfStock.Count;

            return response;
        }
    }
}
