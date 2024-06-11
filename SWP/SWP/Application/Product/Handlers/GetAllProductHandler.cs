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
            try
            {
                var product = _unitOfWork.ProductRepository.GetAll();
                if (!product.Any())
                {
                    response.ErrorMessage = "Don't have any Product";
                    response.IsSuccess = false;
                    return response;
                }
                response.Products = _mapper.Map<List<Infrastructure.Entities.Product>>(product);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when creating new product: " + ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
