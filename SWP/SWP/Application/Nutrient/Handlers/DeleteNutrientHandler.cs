using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            
                var nutrient = _unitOfWork.NutrientRepository.GetById(request.Id);
            if (!nutrient.Enable || nutrient == null)
            {
                response.ErrorMessage = "nutrient not found";
                return response;
            }

            if (nutrient.Enable)
            {
                nutrient.Enable = false;
                _unitOfWork.NutrientRepository.Update(nutrient);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<DeleteNutrientResponse>(nutrient);
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "nutrient has been deleted";
            }
            return response;
        }
    }
}
