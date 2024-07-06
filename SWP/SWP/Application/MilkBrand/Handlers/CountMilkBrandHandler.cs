using Infrastructure;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class CountMilkBrandHandler : IRequestHandler<CountMilkBrandCommand, CountMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        public CountMilkBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CountMilkBrandResponse> Handle(CountMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var milkBrands = _unitOfWork.MilkBrandRepository.GetAll().ToList();
            var count = milkBrands.Count();
            var response = new CountMilkBrandResponse();
            response.IsSuccess = true;
            response.Quantity = count;
            return response;
        }
    }
}
