
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Image : BaseEntity
    {
        public byte[] Content { get; set; }
        public string? Name { get; set; }

    }
}
