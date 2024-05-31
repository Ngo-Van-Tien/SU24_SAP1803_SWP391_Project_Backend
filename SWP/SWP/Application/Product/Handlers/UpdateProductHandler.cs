using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommad, UpdateProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductCommad request, CancellationToken cancellationToken)
        {
            var milkBrand = await _unitOfWork.MilkBrandRepository.GetById(request.Id);



        }
    }
}
