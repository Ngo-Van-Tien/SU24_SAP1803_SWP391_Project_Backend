using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class CountCompanyHandler : IRequestHandler<CountCompanyCommand, CountCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        public CountCompanyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CountCompanyResponse> Handle(CountCompanyCommand request, CancellationToken cancellationToken)
        {
            var companies = _unitOfWork.CompanyRepository.Find(c => c.Enable);
            int count = companies.Count();
            var response = new CountCompanyResponse();
            response.IsSuccess = true;
            response.Quantity = count;
            return response;
        }
    }
}
