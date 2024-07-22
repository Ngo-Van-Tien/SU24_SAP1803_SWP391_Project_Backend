using AutoMapper;
using Infrastructure;
using MediatR;
using PagedList;
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

            // Tìm kiếm và lọc sản phẩm với điều kiện Enable = true
            IQueryable<Infrastructure.Entities.ProductItem> productItemsQuery = _unitOfWork.ProductItemRepository.Find(x =>
                (string.IsNullOrEmpty(request.Name) || x.Product.Name.Contains(request.Name)) &&
                x.Enable &&  // Điều kiện Enable = true
                ((request.StartPrice == null || x.Price >= request.StartPrice) &&
                (request.EndPrice == null || request.EndPrice <= 0 || x.Price <= request.EndPrice)) &&
                ((request.StartAge == null || x.Product.StartAge >= request.StartAge) &&
                (request.EndAge == null || x.Product.EndAge <= request.EndAge)) &&
                (request.MilkBrandIds.Count == 0 || request.MilkBrandIds.Contains(x.Product.MilkBrand.Id)) &&
                (request.Sizes.Count == 0 || request.Sizes.Contains(x.Size)))
                .AsQueryable();

            // Sắp xếp sản phẩm theo giá
            if (request.SortOrder != null)
            {
                if (request.SortOrder.ToLower() == "desc")
                {
                    productItemsQuery = productItemsQuery.OrderByDescending(x => x.Price);
                }
                else if (request.SortOrder.ToLower() == "asc")
                {
                    productItemsQuery = productItemsQuery.OrderBy(x => x.Price);
                }
            }

            // Kiểm tra nếu không có sản phẩm nào
            if (!productItemsQuery.Any())
            {
                response.ErrorMessage = "Don't have any product";
                return response;
            }

            // Phân trang và lấy danh sách sản phẩm cuối cùng
            var productItemsPagedList = productItemsQuery.ToPagedList(request.PageNumber, request.PageSize);

            response.IsSuccess = true;
            response.Data = productItemsPagedList;

            return response;
        }
    }
}
