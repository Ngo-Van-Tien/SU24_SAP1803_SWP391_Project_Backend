using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Handlers
{
    public class UpdateNutrientHandler : IRequestHandler<UpdateNutrientCommand, UpdateNutrientResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UpdateNutrientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateNutrientResponse> Handle(UpdateNutrientCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateNutrientResponse();
            
                var nutrient = _unitOfWork.NutrientRepository.GetById(request.Id);
                
                if (nutrient == null)
                {
                    response.ErrorMessage = "Nutient is not found";
                    return response;
                }

                nutrient.Name = request.Name;
                nutrient.In100g = request.In100g;
                nutrient.InCup = request.InCup;
                nutrient.Unit = request.Unit;

                if(nutrient != null)
                {
                    _unitOfWork.NutrientRepository.Update(nutrient);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<UpdateNutrientResponse>(nutrient);
                    response.IsSuccess = true;
            }

            return response;
        }
    }
}
