using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ProductItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public bool Enable { get; set; }
    }
}
