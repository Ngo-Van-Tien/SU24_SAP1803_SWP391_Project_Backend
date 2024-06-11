using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class GetProductItemsHandler : IRequestHandler<GetProductItemsCommand, GetProductItemsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductItemsResponse> Handle(GetProductItemsCommand request, CancellationToken cancellationToken)
        {
            var response = new GetProductItemsResponse();
            var productItems = _unitOfWork.ProductItemRepository.Find(x => (string.IsNullOrEmpty(request.Name) || x.Product.Name.Contains(request.Name)) &&
                                                                           (x.Price >= request.StartPrice && (request.EndPrice > 0 && x.Price <= request.EndPrice)) &&
                                                                           (request.Sizes.Count == 0 || request.Sizes.Contains(x.Size)), request.PageNumber, request.PageSize);
            response.IsSuccess = true;
            response.Data = productItems;

            return response;
        }
    }
}
