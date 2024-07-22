using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;
using static SWPApi.Application.Order.Responses.Top5ProductHightestSaleResponse;

namespace SWPApi.Application.Order.Handlers
{
    public class Top5ProductHightestSaleHandler : IRequestHandler<Top5ProductHightestSaleCommand, Top5ProductHightestSaleResponse>
    {
        IUnitOfWork _unitOfWork;
        public Top5ProductHightestSaleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Top5ProductHightestSaleResponse> Handle(Top5ProductHightestSaleCommand request, CancellationToken cancellationToken)
        {
            var response = new Top5ProductHightestSaleResponse();

            var orderDetails = _unitOfWork.OrderDetailRepository.GetAll()
                                   .Where(od => od.Order.Status == "DELIVERED"
                                   && od.Order.Enable)
                                   .ToList();

            var topProducts = orderDetails.GroupBy(od => od.ProductItem.Product.Name)
                                          .Select(g => new ProductSalesDetail
                                          {
                                              ProductName = g.Key,
                                              QuantitySold = g.Sum(od => od.Quantity),
                                              TotalSales = g.Sum(od => od.Price * od.Quantity)
                                          })
                                          .OrderByDescending(p => p.TotalSales)
                                          .Take(5)
                                          .ToList();

            response.TopProducts = topProducts;
            response.IsSuccess = true;
            return response;
        }
    }
}
