using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class GetOrderByStatusHandler : IRequestHandler<GetOrderByStatusCommand, GetOrderByStatusResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetOrderByStatusHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetOrderByStatusResponse> Handle(GetOrderByStatusCommand request, CancellationToken cancellationToken)
        {
            
            var response = new GetOrderByStatusResponse();
            var orders = _unitOfWork.OrderRepository.Find(x => (x.Status.Equals(request.Status)|| request.Status == null) && x.Enable).ToList();
            response.Data = orders;
            response.IsSuccess = true;
            return response;
        }
    }
}
