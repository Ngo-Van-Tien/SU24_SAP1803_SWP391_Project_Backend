using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.Nutrient.Commands;
using SWPApi.Application.Nutrient.Responses;

namespace SWPApi.Application.Nutrient.Handlers
{
    public class GetNutrientsHandler : IRequestHandler<GetNutrientsCommand, GetNutrientsResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetNutrientsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetNutrientsResponse> Handle(GetNutrientsCommand request, CancellationToken cancellationToken)
        {
            var response = new GetNutrientsResponse();

            var nutrient = _unitOfWork.NutrientRepository.Find(c => c.Enable).ToList();

            response.Data = nutrient;
            response.IsSuccess = true;

            return response;
        }
    }
}
