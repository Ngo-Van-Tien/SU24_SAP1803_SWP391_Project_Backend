using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class GetByIdProductItemHandler : IRequestHandler<GetByIdProductItemCommand, GetByIdProductItemResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByIdProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetByIdProductItemResponse> Handle(GetByIdProductItemCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByIdProductItemResponse();
            var productItem = _unitOfWork.ProductItemRepository.GetById(request.Id);
            if(productItem == null)
            {
                response.ErrorMessage = "Product Item is not found";
                return response;
            }
            if (!productItem.Enable)
            {
                response.ErrorMessage = "Product Item is disabled";
                return response;
            }

            response = _mapper.Map<GetByIdProductItemResponse>(productItem);
            response.IsSuccess = true;
            return response;
        }
    }
}
