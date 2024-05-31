using AutoMapper;
using Infrastructure.Entities;
using SWPApi.Application.Company.Responses;
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
            CreateMap<Company, AddCompanyResponse>();
            CreateMap<Product, GetProductResponse>();
            CreateMap<MilkBrand, AddMilkBrandResponse>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));
            CreateMap<MilkBrand, UpdateMilkBrandResponse>();
            CreateMap<Product, AddProductResponse>()
                .ForMember(dest => dest.MilkBrandId, opt => opt.MapFrom(src => src.MilkBrand.Id));
        }
    }
}
