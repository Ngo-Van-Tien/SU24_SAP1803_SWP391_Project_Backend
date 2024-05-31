using AutoMapper;
using Infrastructure.Entities;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.MilkFunction.Responses;
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
            // Company
            CreateMap<Company, AddCompanyResponse>();
            CreateMap<Company, UpdateCompanyResponse>();
            CreateMap<Company, DeleteCompanyResponse>();
            
            // Milk Brand
            CreateMap<Product, GetProductResponse>();
            CreateMap<MilkBrand, AddMilkBrandResponse>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));
            CreateMap<MilkBrand, UpdateMilkBrandResponse>();

            // Milk Function
            CreateMap<MilkFunction, AddMilkFunctionResponse>();
            CreateMap<MilkFunction, UpdateMilkFunctionResponse>();
            CreateMap<MilkFunction, DeleteMilkFunctionResponse>();

            // Product 
            CreateMap<Product, AddProductResponse>()
                .ForMember(dest => dest.MilkBrandId, opt => opt.MapFrom(src => src.MilkBrand.Id));
            CreateMap<Product, UpdateProductResponse>();
        }
    }
}
