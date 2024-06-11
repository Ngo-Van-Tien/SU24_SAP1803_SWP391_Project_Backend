using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Handlers
{
    public class GetAllNutrientHandler : IRequestHandler<GetAllNutrientCommand, GetAllNutrientResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllNutrientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllNutrientResponse> Handle(GetAllNutrientCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllNutrientResponse();
            try
            {
                var nutrient = _unitOfWork.NutrientRepository.GetAll();
                if (!nutrient.Any())
                {
                    response.ErrorMessage = "Don't have any Nutrient";
                    response.IsSuccess = false;
                    return response;
                }
                response.Nutrients = _mapper.Map<List<Infrastructure.Entities.Nutrient>>(nutrient);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when creating new nutrient: " + ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
