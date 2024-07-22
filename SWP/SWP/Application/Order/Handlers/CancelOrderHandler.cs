using Azure;
using Infrastructure;
using Infrastructure.Constans;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, CancelOrderResponse>
    {
        IUnitOfWork _unitOfWork;
        public CancelOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CancelOrderResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var respone = new CancelOrderResponse();
            var order = _unitOfWork.OrderRepository.GetById(request.Id);
            if(order == null || !order.Enable)
            {
                respone.ErrorMessage = "Order not found or not enabled";
                return respone;
            }
            if (order.Status == OrderConstant.PROCESSING_STATUS || order.Status == OrderConstant.DELIVERING_STATUS)
            {
                order.Status = OrderConstant.CANCEL_STATUS;
                if (order.StatusPayment == OrderConstant.PAID_STATUS)
                {
                    order.StatusPayment = OrderConstant.WAITREFUNDED_STATUS;
                }
                _unitOfWork.OrderRepository.Update(order);
                await _unitOfWork.SaveChangesAsync();

                var orderDetails = _unitOfWork.OrderDetailRepository.Find(x => x.Order.Id == request.Id);
                var productItems = _unitOfWork.ProductItemRepository.Find(pi => orderDetails.Select(x => x.ProductItem.Id).Contains(pi.Id));
                foreach(var productItem in productItems)
                {
                    var quantity = orderDetails.FirstOrDefault(x => x.ProductItem.Id == productItem.Id).Quantity;
                    productItem.Quantity = productItem.Quantity + quantity;
                }
                _unitOfWork.ProductItemRepository.UpdateRange(productItems);
                await _unitOfWork.SaveChangesAsync();
                respone.Order = order;
                respone.IsSuccess = true;
            }
            else
            {
                respone.ErrorMessage = "Order cannot be cancelled in its current status";
            }
            return respone;
        }
    }
}
