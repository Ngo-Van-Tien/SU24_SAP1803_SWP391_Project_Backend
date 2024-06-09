﻿using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, DeleteResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DeleteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteResponse();
            try
            {
                var productItem = _unitOfWork.ProductItemRepository.GetById(request.Id);
                if (productItem == null)
                {
                    response.ErrorMessage = "Product Item is not found";
                    return response;
                }
                 _unitOfWork.ProductItemRepository.Remove(productItem);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<DeleteResponse>(productItem);
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.ErrorMessage = "Error when delete product item " + ex.Message;   
            }
            return response;
        }
    }
}
