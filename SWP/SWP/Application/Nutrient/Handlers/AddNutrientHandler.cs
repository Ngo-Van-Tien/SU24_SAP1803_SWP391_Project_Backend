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
            var response = new AddNutrientResponse();
            try
            {
                var nutrient = new Infrastructure.Entities.Nutrient
                {
                    Name = request.Name,
                    In100g = request.In100g,
                    InCup = request.InCup,
                    Unit = request.unit
                };
                
                if (nutrient != null)
                {
                    _unitOfWork.NutrientRepository.Add(nutrient);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<AddNutrientResponse>(nutrient);
                    response.IsSuccess = true;
                    
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when add new Nutrient " + ex.Message;
            }
            return response;
        }
    }
}
