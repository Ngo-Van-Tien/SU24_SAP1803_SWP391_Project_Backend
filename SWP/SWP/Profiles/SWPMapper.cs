﻿using AutoMapper;
using Infrastructure.Entities;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.MilkFunction.Responses;
using SWPApi.Application.Nutrient.Responses;
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
            CreateMap<MilkBrand, DeleteMilkBrandResponse>();
            CreateMap<MilkBrand, AddMilkBrandResponse>();
            CreateMap<MilkBrand, UpdateMilkBrandResponse>();
            CreateMap<MilkBrand, GetAllMilkBrandResponse>();

            // Milk Function
            CreateMap<MilkFunction, AddMilkFunctionResponse>();
            CreateMap<MilkFunction, UpdateMilkFunctionResponse>();
            CreateMap<MilkFunction, DeleteMilkFunctionResponse>();

            //Nutrient
            CreateMap<Nutrient, AddNutrientResponse>();
            CreateMap<Nutrient, UpdateNutrientResponse>();
            CreateMap<Nutrient, DeleteNutrientResponse>();

            // Product
            CreateMap<Product, GetProductResponse>();
        }
    }
}
