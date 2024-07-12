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
                                                                           ((request.StartPrice == null || x.Price >= request.StartPrice) && (request.EndPrice == null || request.EndPrice <= 0 || x.Price <= request.EndPrice)) &&
                                                                           ((request.StartAge == null || x.Product.StartAge >= request.StartAge) && (request.EndAge == null || x.Product.EndAge <= request.EndAge)) &&
                                                                           (request.MilkBrandIds.Count == 0 || request.MilkBrandIds.Contains(x.Product.MilkBrand.Id)) &&
                                                                           (request.Sizes.Count == 0 || request.Sizes.Contains(x.Size)), request.PageNumber, request.PageSize);
            productItems = (PagedList.IPagedList<Infrastructure.Entities.ProductItem>)productItems.Where(pi => pi.Enable);
            response.IsSuccess = true;
            response.Data = productItems;

            return response;
        }
    }
}
