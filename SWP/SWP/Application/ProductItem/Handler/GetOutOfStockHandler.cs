using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class GetOutOfStockHandler : IRequestHandler<GetOutOfStockCommand, GetOutOfStockResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetOutOfStockHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetOutOfStockResponse> Handle(GetOutOfStockCommand request, CancellationToken cancellationToken)
        {
            var response = new GetOutOfStockResponse();
            var productItems = _unitOfWork.ProductItemRepository.Find(x => x.Quantity == 0, request.PageNumber, request.PageSize);

            productItems = (PagedList.IPagedList<Infrastructure.Entities.ProductItem>)productItems.Where(pi => pi.Enable);
            if (productItems.Any())
            {
                response.Data = productItems;
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "Do not have any products";
            }

            return response;
        }
    }
}
