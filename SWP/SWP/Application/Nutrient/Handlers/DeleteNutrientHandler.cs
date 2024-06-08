using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Handlers
{
    public class DeleteNutrientHandler : IRequestHandler<DeleteNutrientCommand, DeleteNutrientResponse>
    { 
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DeleteNutrientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteNutrientResponse> Handle(DeleteNutrientCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteNutrientResponse();
            try
            {
                var nutrient = _unitOfWork.NutrientRepository.GetById(request.Id);
                
                if (nutrient != null)
                {
                    _unitOfWork.NutrientRepository.Remove(nutrient);
                    _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<DeleteNutrientResponse>(nutrient);
                    response.IsSuccess = true;
                    return response;
                }
                response.ErrorMessage = "Nutrient is not found";
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when delete nutrient" + ex.Message;
            }
            return response;
        }
    }
}
