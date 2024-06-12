using AutoMapper;
using Infrastructure;
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

            var payment = new Payment()
            {
                Method = request.Method,
                PaymentAmount = request.PaymentAmount,
                PaymentDate = request.PaymentDate,
                Order = order,
            };

            _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            return response;
        }
    }
}
