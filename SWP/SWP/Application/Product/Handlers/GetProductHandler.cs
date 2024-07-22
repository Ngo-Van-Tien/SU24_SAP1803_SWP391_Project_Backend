using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetProductHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.ProductRepository.GetById(request.Id);
            var response = new GetProductResponse();
            if (product != null && product.Enable)
            {
                response = _mapper.Map<GetProductResponse>(product);
                if(product.Image != null)
                {
                   response.ImageBase64 = Convert.ToBase64String(product.Image.Content, 0, product.Image.Content.Length);
                }
                response.MilkBrand = product.MilkBrand;
                response.IsSuccess = true;
                return response;
            }

            response.ErrorMessage = "The product is not found";
            return response;
        }
    }
}
