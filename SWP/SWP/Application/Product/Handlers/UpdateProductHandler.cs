using AutoMapper;
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
        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetById(request.Id);
            var response = new UpdateProductResponse();
            if(product == null)
            {
                response.ErrorMessage = "Milk brand is not found";
                return response;
            }
            var milkBrand = await _unitOfWork.MilkBrandRepository.GetById(request.MilkBrandId.Value);
            if (milkBrand == null)
            {
                response.ErrorMessage = "milkBrand is not existing";
                return response;
            }
            else if (request.MilkBrandId.Equals(""))
            {
                milkBrand = null;
            }
            product.Name = request.Name;
            product.Description = request.Description;
            product.AgeRange = request.AgeRange;
            product.Price = (decimal)request.Price;

            await _unitOfWork.ProductRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            return response;
        }
    }
}
