using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class AddHandler : IRequestHandler<AddCommand, AddResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AddHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddResponse> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var response = new AddResponse();
            
                var productItem = new Infrastructure.Entities.ProductItem
                {
                    Quantity = request.Quantity,
                    Price = request.Price,
                    Size = request.Size,
                };
                
                productItem.Product = _unitOfWork.ProductRepository.GetById(request.ProductId);   
                
                if(productItem.Product == null)
                {
                    response.ErrorMessage = "Product is not found";
                }
                else
                {
                    _unitOfWork.ProductItemRepository.Add(productItem);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<AddResponse>(productItem);
                    response.IsSuccess = true;
                }
            
            return response;
        }
    }
}
