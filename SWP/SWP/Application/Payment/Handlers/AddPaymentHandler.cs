using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Payment.Commands;
using SWPApi.Application.Payment.Responses;

namespace SWPApi.Application.Payment.Handlers
{
    public class AddPaymentHandler : IRequestHandler<AddPaymentCommand, AddPaymentResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AddPaymentHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddPaymentResponse> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            var response = new AddPaymentResponse();
            try
            {
                var payment = new Infrastructure.Entities.Payment
                {
                    Method = request.Method,
                };
                if(payment != null)
                {
                    _unitOfWork.PaymentRepository.Add(payment);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<AddPaymentResponse>(payment);
                    response.IsSuccess = true;
                }
            }catch (Exception ex)
            {
                response.ErrorMessage = "Error when create new payment " + ex.Message;
            }
            return response;
        }
    }
}
