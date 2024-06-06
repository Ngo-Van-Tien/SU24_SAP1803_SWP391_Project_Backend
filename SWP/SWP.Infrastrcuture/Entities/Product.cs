using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string AgeRange { get; set; }
        [ForeignKey("MilkBrandId")]
        public MilkBrand MilkBrand { get; set; }
        [ForeignKey("ImageId")]
        public ImageFile? Image { get; set; }
    }
}
