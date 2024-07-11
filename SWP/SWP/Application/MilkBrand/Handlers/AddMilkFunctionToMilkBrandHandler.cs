using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class AddMilkFunctionToMilkBrandHandler : IRequestHandler<AddMilkFunctionToMilkBrandCommand, AddMilkFunctionToMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        public AddMilkFunctionToMilkBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AddMilkFunctionToMilkBrandResponse> Handle(AddMilkFunctionToMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new AddMilkFunctionToMilkBrandResponse();
            var milkBrand = _unitOfWork.MilkBrandRepository.GetById(request.Id);

            var milkFunction = _unitOfWork.MilkFunctionRepository.Find(x => request.MilkFunctionIds.Contains(x.Id) && x.Enable).ToList();
            if(milkBrand != null && milkBrand.Enable)
            {
                var milkBrandFunctions = new List<MilkBrandFunction>();
                foreach ( var item in milkFunction)
                {
                    var milkBrandFunction = new MilkBrandFunction();
                    milkBrandFunction.MilkFunction = item;
                    milkBrandFunction.MilkBrand = milkBrand;
                    var check = _unitOfWork.MilkBrandFunctionRepository.Find(x => x.MilkBrand.Id == milkBrandFunction.MilkBrand.Id 
                                                                                    && x.MilkFunction.Id == milkBrandFunction.MilkFunction.Id);
                    if (!check.Any()) { milkBrandFunctions.Add(milkBrandFunction); }
                }
                _unitOfWork.MilkBrandFunctionRepository.AddRange(milkBrandFunctions);
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "Milk Brand is no existed";
            }
            return response;
        }
    }
}
