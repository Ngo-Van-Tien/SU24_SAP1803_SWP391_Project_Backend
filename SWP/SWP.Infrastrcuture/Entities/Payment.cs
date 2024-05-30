using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentType { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
