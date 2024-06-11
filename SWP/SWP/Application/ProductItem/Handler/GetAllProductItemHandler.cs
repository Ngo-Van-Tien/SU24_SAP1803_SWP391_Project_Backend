using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class GetAllProductItemHandler : IRequestHandler<GetAllProductItemCommand, GetAllProductItemResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllProductItemResponse> Handle(GetAllProductItemCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllProductItemResponse();
            try
            {
                var productItem = _unitOfWork.ProductItemRepository.GetAll();
                if(!productItem.Any())
{
                    response.ErrorMessage = "Don't have any ProductItem";
                    response.IsSuccess = false;
                    return response;
                }
                response.ProductItems = _mapper.Map<List<Infrastructure.Entities.ProductItem>>(productItem);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when creating new productItem: " + ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
