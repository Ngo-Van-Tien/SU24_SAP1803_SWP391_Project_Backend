using AutoMapper;
using MediatR;
using SWPApi.Application.Payments.Commands;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Handlers
{
    public class ReturnPaymentVnPayHandler : IRequestHandler<ReturnPaymentVnPayCommand, ReturnPaymentVnPayResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReturnPaymentVnPayHandler(IConfiguration configuration, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ReturnPaymentVnPayResponse> Handle(ReturnPaymentVnPayCommand request, CancellationToken cancellationToken)
        {
            var response = new ReturnPaymentVnPayResponse();

            if (request.QueryString.Count > 0)
            {
                string vnp_HashSecret = _configuration["vnp_HashSecret"];
                var vnpayData = request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();

                foreach (var key in vnpayData.Keys)
                {
                    if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(key, vnpayData[key]);
                    }
                }

                string orderCode = Convert.ToString(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                string vnp_SecureHash = request.QueryString["vnp_SecureHash"];
                string TerminalID = request.QueryString["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                string bankCode = request.QueryString["vnp_BankCode"];

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {
                        // Thực hiện các thao tác khi thanh toán thành công
                        response.Message = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                        response.Amount = vnp_Amount;
                        response.Status = true;
                    }
                    else
                    {
                        // Thanh toán không thành công
                        response.Status = false;
                        response.Message = "Có lỗi xảy ra trong quá trình xử lý. Mã lỗi: " + vnp_ResponseCode;
                    }

                    response.TerminalID = TerminalID;
                    response.OrderId = orderCode;
                    response.VnpayTranId = vnpayTranId;
                    response.BankCode = bankCode;
                }
            }

            return response;
        }
    }
}
