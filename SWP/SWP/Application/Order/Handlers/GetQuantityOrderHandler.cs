using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class GetQuantityOrderHandler : IRequestHandler<GetQuantityOrderCommand, GetQuantityOrderResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetQuantityOrderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<GetQuantityOrderResponse> Handle(GetQuantityOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new GetQuantityOrderResponse();
            if(request.Status == null)
            {
                var orders = _unitOfWork.OrderRepository.GetAll().ToList();
                var count = orders.Count(); 
                response.Quantity = count;
                response.IsSuccess = true;
            }else
            {
                var orders = _unitOfWork.OrderRepository.Find(x => x.Status.Equals(request.Status) && x.Enable);
                var count = orders.Count();
                response.Quantity = count;
                response.IsSuccess = true;
            }
            return response;
        }
    }
}
