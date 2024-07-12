using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, GetProductsResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetProductsResponse> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var response = new GetProductsResponse();

            var products = _unitOfWork.ProductRepository.Find(x => (string.IsNullOrEmpty(request.Name) || x.Name.Contains(request.Name)) && x.Enable, request.PageNumber, request.PageSize);
            response.PageNumber = request.PageNumber;
            response.PageSize = request.PageSize;
            response.TotalElements = _unitOfWork.ProductRepository.GetAll().Count();
            response.Data = products;
            response.IsSuccess = true;

            return response;
        }
    }
}
