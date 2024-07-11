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
        public string Method { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public bool Enable { get; set; }
    }
}
