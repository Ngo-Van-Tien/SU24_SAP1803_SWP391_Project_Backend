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
            try
            {
                var productItem = _unitOfWork.ProductItemRepository.GetById(request.Id);
                if(productItem == null)
                {
                    response.ErrorMessage = "Product Item is not found";
                    return response;
                }
                var product = _unitOfWork.ProductRepository.GetById(request.ProductId.Value);
                if (product == null)
                {
                    response.ErrorMessage = "Product is not found";
                    return response;
                }
                productItem.Quantity = (int)request.Quantity;
                productItem.Price = (decimal) request.Price;
                productItem.Size = (int)request.Size;
                productItem.Product = product;

                if(productItem != null)
                {
                    _unitOfWork.ProductItemRepository.Update(productItem);
                    _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<UpdateResponse>(productItem);
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when update produc item " + ex.Message;
            }
            return response;
        }
    }
}
