﻿using Infrastructure.Entities;
using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetOrderResponse : BaseResponse
    {
        public decimal TotalPriceProduct { get; set; }
        public decimal ShipFees { get; set; }
        public decimal FinalPrice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Infrastructure.Entities.OrderDetail> OrderDetails { get; set; }
    }
}