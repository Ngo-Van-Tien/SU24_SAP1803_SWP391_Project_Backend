using Infrastructure.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWPApi.Application.ProductItem.Response
{
    public class GetByIdProductItemResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public Infrastructure.Entities.Product Product { get; set; }
    }
}
