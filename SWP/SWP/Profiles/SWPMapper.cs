﻿using AutoMapper;
using Infrastructure.Entities;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.MilkFunction.Responses;
using SWPApi.Application.Nutrient.Responses;
using SWPApi.Application.Order.Responses;
using SWPApi.Application.Product.Responses;
using SWPApi.Application.ProductItem.Response;
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
            CreateMap<Company, GetByIdResponse>();
            

            // Milk Brand
            CreateMap<MilkBrand, DeleteMilkBrandResponse>();
            CreateMap<MilkBrand, AddMilkBrandResponse>();
            CreateMap<MilkBrand, UpdateMilkBrandResponse>();
            CreateMap<MilkBrand, GetByIdMilkBrandResponse>();


            // Milk Function
            CreateMap<MilkFunction, AddMilkFunctionResponse>();
            CreateMap<MilkFunction, UpdateMilkFunctionResponse>();
            CreateMap<MilkFunction, DeleteMilkFunctionResponse>();
            CreateMap<MilkFunction, GetAllMilkFunctionResponse>();
            CreateMap<MilkFunction, GetByIdMilkFunctionResponse>();


            //Nutrient
            CreateMap<Nutrient, AddNutrientResponse>();
            CreateMap<Nutrient, UpdateNutrientResponse>();
            CreateMap<Nutrient, DeleteNutrientResponse>();
            CreateMap<Nutrient, GetByIdNutrientResponse>();

            // Product
            CreateMap<Product, GetProductResponse>();
            CreateMap<Product, AddProductResponse>();
            CreateMap<Product, UpdateProductResponse>();
            CreateMap<Product,GetAllProductResponse>();

            // Product Item
            CreateMap<ProductItem, AddResponse>();
            CreateMap<ProductItem, UpdateResponse>();
            CreateMap<ProductItem, DeleteResponse>();
            CreateMap<ProductItem, GetAllProductItemResponse>();
            CreateMap<ProductItem, GetByIdProductItemResponse>();

            //Order
            CreateMap<Order, GetOrderResponse>();
            CreateMap<Order, GetOrdersResponse.OrderDisplay>()
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreatedDate));

        }
    }
}
