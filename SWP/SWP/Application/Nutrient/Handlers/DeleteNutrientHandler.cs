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
            var nutrient = await _unitOfWork.NutrientRepository.GetById(request.Id);
            var response = new DeleteNutrientResponse();
            if (nutrient != null)
            {
                await _unitOfWork.NutrientRepository.DeleteNutrient(nutrient);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<DeleteNutrientResponse>(nutrient);
                response.IsSuccess = true;
                return response;
            }
            response.ErrorMessage = "Nutrient is not found";
            return response;
        }
    }
}
