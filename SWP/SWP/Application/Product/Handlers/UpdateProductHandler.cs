﻿using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product =  _unitOfWork.ProductRepository.GetById(request.Id);
            var response = new UpdateProductResponse();
            if(product == null || !product.Enable)
            {
                response.ErrorMessage = "Product is not found";
                return response;
            }

            var image = product.Image;
            var milkBrand = _unitOfWork.MilkBrandRepository.GetById(request.MilkBrandId);
            if (milkBrand == null || !milkBrand.Enable)
            {
                response.ErrorMessage = "milkBrand is not existing";
                return response;
            }
            

            if (request.Image != null && request.Image.Length > 0)
            {

                using (var stream = new MemoryStream())
                {
                    await request.Image.CopyToAsync(stream);
                    image = new ImageFile() { Content = stream.ToArray() };
                    _unitOfWork.ImageRepository.Add(image);
                }
            }
            product.Image = image;
            product.Name = request.Name;
            product.Description = request.Description;
            product.StartAge = request.StartAge;
            product.EndAge = request.EndAge;
            
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            return response;
        }
    }
}
