using AutoMapper;
using Azure;
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
            var response = new GetAllMilkBrandResponse();
            
                var milkBrands = _unitOfWork.MilkBrandRepository.GetAll().ToList();
                if (!milkBrands.Any())
                {
                    response.ErrorMessage = "Do not have any milk brand";
                }
                else
                {
                    response.Data = milkBrands;
                    response.IsSuccess = true;
                }
             
            return response;
        }
    }
}
