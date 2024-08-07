﻿using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            ImageFile image = null;
            var response = new AddProductResponse();
            if (request.Image != null && request.Image.Length > 0)
            {

                using (var stream = new MemoryStream())
                {
                    await request.Image.CopyToAsync(stream);
                    image = new ImageFile() { Content = stream.ToArray() };
                    _unitOfWork.ImageRepository.Add(image);
                }
            }
            //create Entity
            var product = new Infrastructure.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                StartAge = request.StartAge,
                EndAge = request.EndAge,
                Image = image,
                Enable = true
            };

            
            product.MilkBrand = _unitOfWork.MilkBrandRepository.GetById(request.MilkBrandId);
            

            if (product.MilkBrand == null  || !product.MilkBrand.Enable) 
            {
                response.ErrorMessage = "The MilkBrand isn't found";
                return response;
            }
            if (product != null)
            {
                _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<AddProductResponse>(product);
                response.IsSuccess = true;
                return response;
            }

            response.ErrorMessage = "Error at adding product";
            return response;
        }
    }
}