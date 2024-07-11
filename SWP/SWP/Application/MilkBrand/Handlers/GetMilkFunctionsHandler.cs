using Infrastructure;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class GetMilkFunctionsHandler : IRequestHandler<GetMilkFunctionsCommand, GetMilkFunctionsResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetMilkFunctionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetMilkFunctionsResponse> Handle(GetMilkFunctionsCommand request, CancellationToken cancellationToken)
        {
            var response = new GetMilkFunctionsResponse();

            var milkFunctions = _unitOfWork.MilkBrandFunctionRepository
                                                .Find(mbf => mbf.MilkBrand.Id == request.Id && mbf.MilkBrand.Enable && mbf.MilkFunction.Enable)
                                                .Select(mf => mf.MilkFunction)
                                                .ToList();

            if (milkFunctions != null && milkFunctions.Any())
            {

                response.Data = milkFunctions;
                response.IsSuccess = milkFunctions.Any();
                response.ErrorMessage = response.IsSuccess ? "" : "No milk functions found for the specified milk brand.";
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "No milk functions found for the specified milk brand.";
            }

            return response;
        }
    }
}
