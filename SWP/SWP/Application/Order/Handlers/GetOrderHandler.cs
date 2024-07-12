using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class GetOrderHandler : IRequestHandler<GetOrderCommand, GetOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetOrderResponse> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _unitOfWork.OrderRepository.GetById(request.Id);
            var response = new GetOrderResponse();
            if (order != null && order.Enable)
            {
                response = _mapper.Map<GetOrderResponse>(order);
                response.OrderDetails = _unitOfWork.OrderDetailRepository.Find(x => x.Order.Id == request.Id).ToList();
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "The order is not found or is disabled.";
            }
            return response;
        }
    }
}
