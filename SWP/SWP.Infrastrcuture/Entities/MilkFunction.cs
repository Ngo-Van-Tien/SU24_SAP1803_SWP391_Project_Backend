using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class MilkFunction : BaseEntity
    {
        public string Name {get; set;}
        public bool Enable { get; set; }
    }
}
