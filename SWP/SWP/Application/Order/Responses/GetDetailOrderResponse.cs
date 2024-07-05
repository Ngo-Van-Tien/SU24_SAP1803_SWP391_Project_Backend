using Infrastructure.Models;

namespace SWPApi.Application.Order.Responses
{
    public class GetDetailOrderResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<DetailOrder> OrderDeatil { get; set; }
        public class DetailOrder
        {
            public string Name { get; set; }
            public int Size { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
        public decimal ShipFees { get; set; }
        public decimal FinalPrice { get; set; }
        public string Method { get; set; }
    }
}
