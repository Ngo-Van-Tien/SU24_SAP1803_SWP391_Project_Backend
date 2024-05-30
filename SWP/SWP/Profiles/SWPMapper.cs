using AutoMapper;
using Infrastructure.Entities;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.Product.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPApi.Profiles
{
    public class SWPMapper : Profile
    {
        public SWPMapper()
        {
            CreateMap<Product, GetProductResponse>();
            CreateMap<MilkBrand, AddMilkBrandResponse>();
        }
    }
}
