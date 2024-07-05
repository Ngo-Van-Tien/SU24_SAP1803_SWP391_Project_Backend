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
            if(order == null)
            {
                respone.ErrorMessage = "Order is not existed";
                return respone;
            }
            else
            {
                if(order.Status != OrderConstant.SUCCESS_STATUS)
                {
                    order.Status = OrderConstant.CANCEL_STATUS;
                    _unitOfWork.OrderRepository.Update(order);
                    await _unitOfWork.SaveChangesAsync();
                    respone.Order = order;
                    respone.IsSuccess = true;
                }
            }
            return respone;
        }
    }
}
