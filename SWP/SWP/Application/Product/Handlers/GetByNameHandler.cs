using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetByNameHandler : IRequestHandler<GetByNameCommand, GetByNameResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByNameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByNameResponse> Handle(GetByNameCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByNameResponse();
            try
            {
                var products = _unitOfWork.ProductRepository.Find(x => string.IsNullOrEmpty(request.Name) || request.Name.Contains(x.Name) || x.MilkBrand.Company.Name.Contains(request.Name) || x.MilkBrand.Company.Name.Contains(request.Name) , request.PageNumber, request.PageSize);

                if (products.Any())
                {
                    response.Data = products;
                    response.IsSuccess = true;
                }
                else
                {
                    response.ErrorMessage = "No product match with " + request.Name;
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error at GetProductByName " + ex.Message;
            }
            return response;
        }
    }
}
