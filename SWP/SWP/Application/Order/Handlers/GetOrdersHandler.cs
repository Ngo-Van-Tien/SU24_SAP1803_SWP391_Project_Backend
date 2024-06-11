using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersCommand, GetOrdersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOrdersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetOrdersResponse> Handle(GetOrdersCommand request, CancellationToken cancellationToken)
        {
            var response = new GetOrdersResponse();
            response.Data = _unitOfWork.OrderRepository.GetAll().ToList();
            response.IsSuccess = true;

            return response;
        }
    }
}
