using Infrastructure;
using MediatR;
using SWPApi.Application.Order.Commands;
using SWPApi.Application.Order.Responses;
using System.Globalization;
using static SWPApi.Application.Order.Responses.SaleReportResponse;

namespace SWPApi.Application.Order.Handlers
{
    public class SaleReportHandler : IRequestHandler<SaleReportCommand, SaleReportResponse>
    {
        IUnitOfWork _unitOfWork;
        public SaleReportHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SaleReportResponse> Handle(SaleReportCommand request, CancellationToken cancellationToken)
        {
            var response = new SaleReportResponse();

            var startDate = request.StartDate ?? DateTime.MinValue;
            var endDate = request.EndDate ?? DateTime.MaxValue;
            var format = request.Format;

            var orders = _unitOfWork.OrderRepository
                            .Find(o => o.CreatedDate >= startDate
                                    && o.CreatedDate <= endDate
                                    && o.Status == "SUCCCESS");

            if (orders.Any())
            {
                if (format == null)
                {
                    var reportDetail = new ReportDetail
                    {
                        Date = (DateTime) startDate,
                        TotalQuantiyTransaction = orders.Count(),
                        TotalTransactionValue = orders.Sum(order => order.TotalPriceProduct),
                        ToTalDeliveryTransaction = orders.Sum(order => order.ShipFees),
                        TotalFinalTransactionValue = orders.Sum(order => order.FinalPrice)
                    };

                    response.ReportDetails.Add(reportDetail);
                    response.IsSuccess = true;
                }
                else
                {
                    switch (format)
                    {
                        case "day":
                            var dailyReport = orders.GroupBy(order => order.CreatedDate.Date)
                                                    .Select(g => new SaleReportResponse.ReportDetail
                                                    {
                                                        Date = g.Key,
                                                        TotalQuantiyTransaction = g.Count(),
                                                        TotalTransactionValue = g.Sum(order => order.TotalPriceProduct),
                                                        ToTalDeliveryTransaction = g.Sum(order => order.ShipFees),
                                                        TotalFinalTransactionValue = g.Sum(order => order.FinalPrice)
                                                    }).ToList();
                            response.ReportDetails = dailyReport;
                            response.IsSuccess = true;
                            break;

                        case "month":
                            var monthlyReport = orders.GroupBy(order => new { order.CreatedDate.Year, order.CreatedDate.Month })
                                                      .Select(g => new SaleReportResponse.ReportDetail
                                                      {
                                                          Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                                                          TotalQuantiyTransaction = g.Count(),
                                                          TotalTransactionValue = g.Sum(order => order.TotalPriceProduct),
                                                          ToTalDeliveryTransaction = g.Sum(order => order.ShipFees),
                                                          TotalFinalTransactionValue = g.Sum(order => order.FinalPrice)
                                                      }).ToList();
                            response.ReportDetails = monthlyReport;
                            response.IsSuccess = true;
                            break;
                    }
                }
            }

            return response;
        }

    }
}
