using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class MilkBrandFunction : BaseEntity
    {
        [ForeignKey("MilkBrandId")]
        public MilkBrand MilkBrand { get; set; }
        [ForeignKey("MilkFunctionId")]
        public MilkFunction MilkFunction { get; set; }
    }
}