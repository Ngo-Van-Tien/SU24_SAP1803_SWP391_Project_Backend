using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Payments.Commands;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Handlers
{
    public class GetPaymentsHandler : IRequestHandler<GetPaymentsCommand, GetPaymentsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPaymentsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetPaymentsResponse> Handle(GetPaymentsCommand request, CancellationToken cancellationToken)
        {
            var response = new GetPaymentsResponse();
            response.Data = _unitOfWork.PaymentRepository.Find( x => true, request.PageNumber, request.PageSize).ToList();
            response.IsSuccess = true;

            return response;
        }
    }
}
