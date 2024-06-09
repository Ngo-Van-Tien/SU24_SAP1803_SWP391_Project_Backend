using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetByMilkBrandHandler : IRequestHandler<GetByMilkBrandCommand, GetByMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByMilkBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByMilkBrandResponse> Handle(GetByMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByMilkBrandResponse();
            try
            {
                var products = _unitOfWork.ProductRepository.Find(x => x.MilkBrand.Id == request.Id, request.pageNumber, request.pageSize);

                if (products.Any())
                {
                    response.Data = products;
                    response.IsSuccess = true;
                }
                else
                {
                    response.ErrorMessage = "No product";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error at get product by milkbrand " + ex.Message;
            }
            return response;
        }
    }
}
