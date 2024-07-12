using Infrastructure;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class UpdateMilkFunctionsHandler : IRequestHandler<UpdateMilkFunctionsCommand, UpdateMilkFunctionsResponse>
    {
        IUnitOfWork _unitOfWork;
        public UpdateMilkFunctionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateMilkFunctionsResponse> Handle(UpdateMilkFunctionsCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateMilkFunctionsResponse();
            var milkBrandFunction = _unitOfWork.MilkBrandFunctionRepository.Find(x => x.MilkBrand.Id == request.Id && x.MilkFunction.Id == request.MilkFunctionId);
            if(milkBrandFunction != null)
            {
                _unitOfWork.MilkBrandFunctionRepository.RemoveRange(milkBrandFunction);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
            }
            return response;
        }
    }
}
