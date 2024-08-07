﻿using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class GetAllProductItemHandler : IRequestHandler<GetAllProductItemCommand, GetAllProductItemResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllProductItemResponse> Handle(GetAllProductItemCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllProductItemResponse();

            var productItems = _unitOfWork.ProductItemRepository.GetAll()
                              .Where(pi => pi.Enable)
                              .ToList();
            if (!productItems.Any())
            {
                response.ErrorMessage = "Don't have any ProductItem";
            }
            else
            {
                response.Data = productItems;
                response.IsSuccess = true;
            }

            return response;
        }
    }
}
