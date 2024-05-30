using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ProductItemId")]
        public ProductItem ProductItem { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
