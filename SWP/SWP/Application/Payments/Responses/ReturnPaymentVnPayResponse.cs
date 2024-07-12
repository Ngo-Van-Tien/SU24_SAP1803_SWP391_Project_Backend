using Infrastructure.Models;

namespace SWPApi.Application.Payments.Responses
{
    public class ReturnPaymentVnPayResponse : BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public long Amount { get; set; }
        public string TerminalID { get; set; }
        public string OrderId { get; set; }
        public long VnpayTranId { get; set; }
        public string BankCode { get; set; }
    }
}
