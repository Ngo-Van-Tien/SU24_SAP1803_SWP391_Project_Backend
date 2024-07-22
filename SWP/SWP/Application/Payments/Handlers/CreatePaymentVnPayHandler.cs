using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Payments.Commands;
using SWPApi.Application.Payments.Responses;

namespace SWPApi.Application.Payments.Handlers
{
    public class CreatePaymentVnPayHandler : IRequestHandler<CreatePaymentVnPayCommand, CreatePaymentVnPayResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Utils _utils;

        public CreatePaymentVnPayHandler(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _utils = new Utils(httpContextAccessor);
        }
        public async Task<CreatePaymentVnPayResponse> Handle(CreatePaymentVnPayCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePaymentVnPayResponse();
            string hostName = System.Net.Dns.GetHostName();
            string vnp_Returnurl = _configuration["VNPAY:vnp_Returnurl"];
            string vnp_Url = _configuration["VNPAY:vnp_Url"];
            string vnp_TmnCode = _configuration["VNPAY:vnp_TmnCode"];
            string vnp_HashSecret = _configuration["VNPAY:vnp_HashSecret"];
            
            VnPayLibrary vnpay = new VnPayLibrary();
            var order = _unitOfWork.OrderRepository.GetById(request.OrderId);
            decimal price = order.FinalPrice;

            vnpay.AddRequestData("vnp_Version", _configuration["VNPAY:Version"]);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", ((int)(order.FinalPrice * 100)).ToString());
            vnpay.AddRequestData("vnp_BankCode", "");
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", System.Net.Dns.GetHostAddresses(hostName).GetValue(0).ToString());
            vnpay.AddRequestData("vnp_Locale", _configuration["VNPAY:vnp_Locale"]);
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + request.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", (request.OrderId).ToString());

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            response.PaymentUrl = paymentUrl;
            response.IsSuccess = true;


            return response;
        }

        
    }         
}
