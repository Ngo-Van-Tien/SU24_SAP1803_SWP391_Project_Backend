using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductModel
            {
                Name = request.ProductName,
                Description = request.ProductDescription,
                Price = request.Price,
                AgeRange = request.AgeRange
            };

        }
    }
}
