using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;

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
            try
            {
                var nutrient = _unitOfWork.NutrientRepository.GetById(request.Id);
                if (nutrient == null)
                {
                    response.ErrorMessage = "Nutrient is not found";
                }
                else
                {
                    response = _mapper.Map<GetByIdNutrientResponse>(nutrient);
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage += ex.Message;
            }
            return response;
        }
    }
}
