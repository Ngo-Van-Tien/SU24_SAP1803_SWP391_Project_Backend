using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Handlers
{
    public class AddNutrientHandler : IRequestHandler<AddNutrientCommand, AddNutrientResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AddNutrientHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddNutrientResponse> Handle(AddNutrientCommand request, CancellationToken cancellationToken)
        {
            var nutrient = new Infrastructure.Entities.Nutrient 
            {
                NutrientName = request.NutrientName,
                In100g = request.In100g,
                InCup = request.InCup,
                unit = request.unit
            };
            var response = new AddNutrientResponse();
            if(nutrient != null)
            {
                await _unitOfWork.NutrientRepository.AddNutrient(nutrient);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<AddNutrientResponse>(nutrient);
                response.IsSuccess = true;
                return response;
            }
            response.ErrorMessage = "Failed to create new nutrient";
            return response;
        }
    }
}
