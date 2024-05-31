using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            //create Entity
            var product = new Infrastructure.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price ?? 0,
                AgeRange = request.AgeRange
            };
            if (request.MilkBrandId.HasValue)
            {
                product.MilkBrand = await _unitOfWork.MilkBrandRepository.GetById(request.MilkBrandId.Value);
            }
            var response = new AddProductResponse();
            if (product != null)
            {
                await _unitOfWork.ProductRepository.AddProduct(product);
                await _unitOfWork.SaveChangesAsync();

                response = _mapper.Map<AddProductResponse>(response);
                response.IsSuccess = true;
                return response;
            }

            response.ErrorMessage = "Error at adding product";
            return response;
        }
    }
}