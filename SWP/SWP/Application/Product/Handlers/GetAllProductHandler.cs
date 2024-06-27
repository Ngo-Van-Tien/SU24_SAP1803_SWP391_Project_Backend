using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, GetAllProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetAllProductResponse> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllProductResponse();
            
                var products = _unitOfWork.ProductRepository.GetAll().ToList();
                if (!products.Any())
                {
                    response.ErrorMessage = "Don't have any Product";
                    return response;
                }
                else
                {
                    response.Data = products;
                    response.IsSuccess = true;
                }
                
            return response;
        }
    }
}
