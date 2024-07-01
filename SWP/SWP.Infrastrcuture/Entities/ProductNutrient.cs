using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ProductNutrient : BaseEntity
    {
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("NutrientId")]
        public Nutrient Nutrient { get; set; }
        public double? In100g { get; set; }
        public double? InCup { get; set; }
        public string Unit { get; set; }
    }
}
