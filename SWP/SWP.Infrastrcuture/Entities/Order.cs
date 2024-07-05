using SWP.Infrastrcuture.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalPriceProduct { get; set; }
        public decimal ShipFees { get; set; }
        public decimal FinalPrice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get;set; }
        public string Status { get; set; }
        public string StatusPayment { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
