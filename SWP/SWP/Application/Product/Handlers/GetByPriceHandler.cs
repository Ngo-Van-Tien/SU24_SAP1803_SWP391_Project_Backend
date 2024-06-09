using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetByPriceHandler : IRequestHandler<GetByPriceCommand, GetByPriceResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByPriceHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByPriceResponse> Handle(GetByPriceCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByPriceResponse();
            try
            {
                var products = _unitOfWork.ProductRepository.Find( x => x.Price >= request.FPrice && x.Price <= request.LPrice, request.pageNumber, request.pageSize);

                if (products.Any())
                {
                    response.Data = products;
                    response.IsSuccess = true;
                }
                else
                {
                    response.ErrorMessage = "No product";
                }
            }catch(Exception ex)
            {
                response.ErrorMessage = "Error at Get by price function " + ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
