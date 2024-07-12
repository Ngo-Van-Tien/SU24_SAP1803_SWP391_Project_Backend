using Infrastructure;
using Infrastructure.Constans;
using Infrastructure.Entities;
using MediatR;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateOrderResponse();
            var user = _unitOfWork.AppUserRepository.Find(x => x.Id == request.UserId).FirstOrDefault();
            if (user == null) {
                response.IsSuccess = false;
                response.ErrorMessage = "The user not found";
            }
            var productItemIds = request.ProductItems.Select(x => x.Id);
            var productItems = _unitOfWork.ProductItemRepository.Find(x => productItemIds.Contains(x.Id));
            foreach (var item in productItems)
            {
                if (!item.Enable)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = $"Product {item.Id} is not enabled";
                    return response;
                }
            }

            var order = new Infrastructure.Entities.Order();
            order.Address = user.Address;
            order.PhoneNumber = user.PhoneNumber;
            order.ShipFees = request.ShipFees;
            order.Status = OrderConstant.PROCESSING_STATUS;
            order.StatusPayment = OrderConstant.UNPAID_STATUS;
            order.User = user;

            decimal totalPrice = 0;
            var orderDetails = new List<OrderDetail>();
            foreach (var item in productItems) 
            {
                var orderDetail = new OrderDetail();
                orderDetail.Order = order;
                var quantityRequest = request.ProductItems.FirstOrDefault(x => x.Id == item.Id).Quantity;
                if (quantityRequest > item.Quantity) 
                {
                    response.ErrorMessage = "Product " + item.Id + " isn't enough quantity";
                    return response;
                }
                orderDetail.Quantity = quantityRequest;
                orderDetail.Price = item.Price * quantityRequest;
                orderDetail.ProductItem = item;
                orderDetail.Order = order;
                totalPrice += orderDetail.Price;
                orderDetails.Add(orderDetail);
            }

            order.TotalPriceProduct = totalPrice;
            order.FinalPrice = totalPrice + request.ShipFees;
            _unitOfWork.OrderDetailRepository.AddRange(orderDetails);

            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Id = order.Id;
            response.Order = order;
            return response;
        }
    }
}
