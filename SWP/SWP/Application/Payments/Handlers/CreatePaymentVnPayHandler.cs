﻿using AutoMapper;
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

        public CreatePaymentVnPayHandler(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<CreatePaymentVnPayResponse> Handle(CreatePaymentVnPayCommand request, CancellationToken cancellationToken)
        {
            var response = new CreatePaymentVnPayResponse();

            string vnp_Returnurl = _configuration["VNPAY:vnp_Returnurl"];
            string vnp_Url = _configuration["VNPAY:vnp_Url"];
            string vnp_TmnCode = _configuration["VNPAY:vnp_TmnCode"];
            string vnp_HashSecret = _configuration["VNPAY:vnp_HashSecret"];

            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (request.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + request.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", request.OrderId);

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            response.PaymentUrl = paymentUrl;
            response.IsSuccess = true;

            return response;
        }

        
    }         
}
