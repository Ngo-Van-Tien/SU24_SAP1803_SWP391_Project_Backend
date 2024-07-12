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

            var product = _unitOfWork.ProductRepository.GetById(request.ProductId);
            if (product == null)
            {
                response.ErrorMessage = "Product is not found";
                return response;
            }

            if (!product.Enable)
            {
                response.ErrorMessage = "Product is not enabled";
                return response;
            }

            var productItem = new Infrastructure.Entities.ProductItem
            {
                Quantity = request.Quantity,
                Price = request.Price,
                Size = request.Size,
                Product = product,
                Enable = true
            };

            _unitOfWork.ProductItemRepository.Add(productItem);
            await _unitOfWork.SaveChangesAsync();

            response = _mapper.Map<AddResponse>(productItem);
            response.IsSuccess = true;

            return response;
        }
    }
}
