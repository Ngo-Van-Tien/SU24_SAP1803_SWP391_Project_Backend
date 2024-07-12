using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;
using System.ComponentModel.DataAnnotations;

namespace SWPApi.Application.ProductItem.Handler
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateResponse();
            
                var productItem = _unitOfWork.ProductItemRepository.GetById(request.Id);
                if(productItem == null)
                {
                    response.ErrorMessage = "Product Item is not found";
                    return response;
                }
            if (!productItem.Enable)
            {
                response.ErrorMessage = "Product Item is disabled";
                return response;
            }
            var product = _unitOfWork.ProductRepository.GetById(request.ProductId);
                if (product == null || !product.Enable)
                {
                    response.ErrorMessage = "Product is not found";
                    return response;
                }
            productItem.Quantity = request.Quantity;
            productItem.Price = request.Price;
            productItem.Size = request.Size;
            productItem.Product = product;

            _unitOfWork.ProductItemRepository.Update(productItem);
            await _unitOfWork.SaveChangesAsync();

            response = _mapper.Map<UpdateResponse>(productItem);
            response.IsSuccess = true;

            return response;
        }
    }
}
