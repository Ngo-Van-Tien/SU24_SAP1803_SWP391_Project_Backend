using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class GetAllMilkBrandHandler : IRequestHandler<GetAllMilkBrandCommand, GetAllMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public GetAllMilkBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllMilkBrandResponse> Handle(GetAllMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var milkBrands = await _unitOfWork.MilkBrandRepository.GetAllMilkBrands();
            var response = new GetAllMilkBrandResponse(milkBrands.ToList());
            response = _mapper.Map<GetAllMilkBrandResponse>(milkBrands);
            if (!milkBrands.ToList().Any()) 
            {
                response.ErrorMessage = "Don't have any Milk Brand";
                return response;
            }
            response.IsSuccess = true;
            return  response;
        }
    }
}
