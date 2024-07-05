using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class SaleReportResponse : BaseResponse
    {
        public List<ReportDetail> ReportDetails { get; set; }
        public SaleReportResponse()
        {
            ReportDetails = new List<ReportDetail>();
        }
        public class ReportDetail
        {
            public DateTime Date { get; set; }
            public string FormattedDate => FormatDate();
            public int TotalQuantiyTransaction { get; set; }
            public decimal TotalTransactionValue { get; set; }
            public decimal ToTalDeliveryTransaction { get; set; }
            public decimal TotalFinalTransactionValue { get; set; }

            private string FormatDate()
            {
                
                if (Date.Day == 1 && Date.Hour == 0 && Date.Minute == 0 && Date.Second == 0)
                {
                    return Date.ToString("yyyy-MM");
                }
                else
                {
                    return Date.ToString("yyyy-MM-dd");
                }
            }
        }


    }
}
