using Infrastructure;
using Infrastructure.Constans;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class UpdateStatusHandler : IRequestHandler<UpdateStatusCommand, UpdateStatusResponse>
    {
        IUnitOfWork _unitOfWork;
        public UpdateStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateStatusResponse> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStatusResponse();
            var order = _unitOfWork.OrderRepository.GetById(request.Id);
            if (order == null)
            {
                response.ErrorMessage = "Order does not exist";
                return response;
            }

            
            if (!IsValidStatusAndPayment(request.Status, request.StatusPayment))
            {
                response.ErrorMessage = "Invalid status or status payment provided";
                return response;
            }

           
            order.Status = request.Status;
            order.StatusPayment = request.StatusPayment;

            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();

            response.Order = order;
            response.IsSuccess = true;
            return response;
        }

        private bool IsValidStatusAndPayment(string status, string statusPayment)
        {
            switch (status)
            {
                case OrderConstant.PROCESSING_STATUS:
                    return statusPayment == OrderConstant.PAID_STATUS ||
                           statusPayment == OrderConstant.UNPAID_STATUS ;
                case OrderConstant.DELIVERING_STATUS:
                    return statusPayment == OrderConstant.UNPAID_STATUS ||
                           statusPayment == OrderConstant.PAID_STATUS ;
                case OrderConstant.DELIVERED_STATUS:
                    return statusPayment == OrderConstant.PAID_STATUS;
                case OrderConstant.CANCEL_STATUS:
                    return statusPayment == OrderConstant.UNPAID_STATUS ||
                           statusPayment == OrderConstant.REFUNDED_STATUS ||
                           statusPayment == OrderConstant.WAITREFUNDED_STATUS;
                default:
                    return false;
            }
        }
    }
}
