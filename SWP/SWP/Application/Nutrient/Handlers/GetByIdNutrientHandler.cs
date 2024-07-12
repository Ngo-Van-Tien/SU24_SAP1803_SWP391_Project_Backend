using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SWPApi.Application.Nutrient.Handlers
{
    public class GetByIdNutrientHandler : IRequestHandler<GetByIdNutrientCommand, GetByIdNutrientResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByIdNutrientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetByIdNutrientResponse> Handle(GetByIdNutrientCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByIdNutrientResponse();
            
            var nutrient = _unitOfWork.NutrientRepository.GetById(request.Id);

            if (!nutrient.Enable || nutrient == null)
            {
                response.ErrorMessage = "nutrient is not found";
            }
            else
            {
                response.Nutrient = nutrient;
                response.IsSuccess = true;
            }

            return response;
        }
    }
}
