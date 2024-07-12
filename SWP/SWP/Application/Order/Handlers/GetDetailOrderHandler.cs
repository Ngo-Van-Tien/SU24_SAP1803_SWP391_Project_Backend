using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class GetDetailOrderHandler : IRequestHandler<GetDetailOrderCommand, GetDetailOrderResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetDetailOrderHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public async Task<GetDetailOrderResponse> Handle(GetDetailOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new GetDetailOrderResponse();

            
            var orderDetail = _unitOfWork.OrderDetailRepository.Find(od => od.Order.Id == request.Id);
            var order = _unitOfWork.OrderRepository.GetById(request.Id);
            if (order == null || !order.Enable)
            {
                response.ErrorMessage = "Order not found or not enabled.";
                return response;
            }
            var payment = _unitOfWork.PaymentRepository.Find(pm => pm.Order.Id == request.Id).FirstOrDefault();

            
            response.Id = order.Id;
            response.Address = order.Address;
            response.PhoneNumber = order.PhoneNumber;
            response.Email = order.User.Email; 
            response.ShipFees = order.ShipFees;
            response.FinalPrice = order.FinalPrice;
            response.Method = payment?.Method ?? "Not paid";


            response.OrderDeatil = orderDetail
                .Select(od => new GetDetailOrderResponse.DetailOrder
                {
                    Name = od.ProductItem.Product.Name,
                    Size = od.ProductItem.Size,
                    Quantity = od.Quantity,
                    Price = od.ProductItem.Price
                })
                .ToList();

            response.IsSuccess = true;
            return response;


        }
    }
}
