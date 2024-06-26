using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public DeleteProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteProductResponse();
            var product = _unitOfWork.ProductRepository.GetById(request.Id);
            if(product == null)
            {
                response.ErrorMessage = "Product is not found";
            }
            else
            {
                _unitOfWork.ProductRepository.Remove(product);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
            }
            return response;
        }
    }
}
