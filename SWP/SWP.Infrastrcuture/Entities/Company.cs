﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Nation { get; set; } 
        public bool Enable { get; set; }
        public ImageFile? Image { get; set; }
        public string? Path { get; set; }
    }
}
