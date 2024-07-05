using AutoMapper;
using Infrastructure;
using Infrastructure.Constans;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Payments.Commands;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Handlers
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreatePaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePaymentResponse();
            var order = _unitOfWork.OrderRepository.GetById(request.OrderId);
            if (order == null) 
            {
                response.ErrorMessage = "The Order isn't found.";
                return response;
            }

            if(request.PaymentAmount < order.FinalPrice)
            {
                response.ErrorMessage = "The payment amount must be more than ordered amount.";
                return response;
            }

            var orderDetails = _unitOfWork.OrderDetailRepository.Find(x => x.Order.Id == order.Id);
            var productItems = _unitOfWork.ProductItemRepository.Find(x => orderDetails.Select(x => x.ProductItem.Id).Contains(x.Id));
            foreach (var productItem in productItems)
            {
                var quantityRequest = orderDetails.FirstOrDefault(x => x.ProductItem.Id == productItem.Id).Quantity;
                productItem.Quantity = productItem.Quantity - quantityRequest;
            }

            _unitOfWork.ProductItemRepository.UpdateRange(productItems);

            var payment = new Payment()
            {
                Method = request.Method,
                PaymentAmount = request.PaymentAmount,
                PaymentDate = request.PaymentDate,
                Order = order,
            };
            
            _unitOfWork.PaymentRepository.Add(payment);
            order.StatusPayment = OrderConstant.PAID_STATUS;
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            return response;
        }
    }
}
