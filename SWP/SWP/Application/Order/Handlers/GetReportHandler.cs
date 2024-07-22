using Azure;
using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Handlers
{
    public class GetReportHandler : IRequestHandler<GetReportCommand, GetReportResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetReportHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public async Task<GetReportResponse> Handle(GetReportCommand request, CancellationToken cancellationToken)
        {
            var response = new GetReportResponse();
            var ordersSuccess = _unitOfWork.OrderRepository
                            .Find(o => o.CreatedDate >= request.StartDay
                                    && o.CreatedDate <= request.EndDay
                                    && o.Status == "DELIVERED"
                                    && o.Enable);
            var ordersFailure = _unitOfWork.OrderRepository
                            .Find(o => o.CreatedDate >= request.StartDay
                                    && o.CreatedDate <= request.EndDay
                                    && o.Status == "CANCEL"
                                    && o.Enable);
            var totalQuantityDelivered = _unitOfWork.OrderRepository
                    .Find(o => o.CreatedDate >= request.StartDay
                             && o.CreatedDate <= request.EndDay
                             && o.Status == "DELIVERED"
                             && o.Enable)
                    .Sum(o => o.ShipFees);
            var totalFinal = _unitOfWork.OrderRepository
                    .Find(o => o.CreatedDate >= request.StartDay
                             && o.CreatedDate <= request.EndDay
                             && o.Status == "DELIVERED"
                             && o.Enable)
                    .Sum(o => o.FinalPrice);
            response.TotalQuantity = ordersSuccess.Count();
            response.TotalQuantityCancel = ordersFailure.Count();
            response.TotalDeliver = totalQuantityDelivered;
            response.TotalFinal = totalFinal;
            response.IsSuccess = true;
            return response;
        }
    }
}
