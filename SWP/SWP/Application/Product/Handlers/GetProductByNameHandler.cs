using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameCommand, GetProductByNameResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetProductByNameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetProductByNameResponse> Handle(GetProductByNameCommand request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.ProductRepository.Find(x => x.Name.Contains(request.Name), request.PageNumber, request.PageSize);
            var response = new GetProductByNameResponse();

            response.Data = products;
            response.IsSuccess = true;

            return response;
        }
    }
}
