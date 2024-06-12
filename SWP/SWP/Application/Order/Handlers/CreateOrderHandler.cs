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
            var user = _unitOfWork.AppUserRepository.Find(x => !string.IsNullOrEmpty(request.Email) && x.Email.ToLower() == request.Email.Trim().ToLower()).FirstOrDefault();
            if (user == null) 
            {
                user = new AppUser();
                user.UserName = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                user.Email = request.Email;
                user.Address = request.Address;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                _unitOfWork.AppUserRepository.Add(user);
                await _unitOfWork.SaveChangesAsync();
            }
            var productItems = _unitOfWork.ProductItemRepository.Find(x => request.ProductItemIds.Contains(x.Id));

            var order = new Infrastructure.Entities.Order();
            order.Address = request.Address;
            order.PhoneNumber = request.PhoneNumber;
            order.ShipFees = request.ShipFees;
            order.Status = OrderConstant.CREATED_STATUS;
            order.User = user;
            decimal totalPrice = 0;
            var orderDetails = new List<OrderDetail>();
            foreach (var item in productItems) 
            {
                var orderDetail = new OrderDetail();
                orderDetail.Order = order;
                orderDetail.Quantity = item.Quantity;
                orderDetail.Price = item.Price;
                orderDetail.ProductItem = item;
                orderDetail.Order = order;
                totalPrice += orderDetail.Price;
                orderDetails.Add(orderDetail);
            }

            order.TotalPriceProduct = totalPrice;
            order.FinalPrice = totalPrice - request.ShipFees;
            _unitOfWork.OrderDetailRepository.AddRange(orderDetails);

            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Order = order;
            return response;
        }
    }
}
