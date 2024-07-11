using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Nutrient : BaseEntity
    {
        public string? Name { get; set; }
        public bool Enable { get; set; }
    }
}
