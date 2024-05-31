using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Nutrient : BaseEntity
    {
        public string? NutrientName { get; set; }
        public int? In100g { get; set; }
        public int? InCup {  get; set; }    
        public string unit { get; set; }
    }
}
