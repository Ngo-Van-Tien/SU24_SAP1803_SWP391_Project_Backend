using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class MilkBrand : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
        public string? Description { get; set; }
        
    }
}
