using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class UnLockCompanyHandler : IRequestHandler<UnLockCompanyCommand, UnLockCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        public UnLockCompanyHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public async Task<UnLockCompanyResponse> Handle(UnLockCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _unitOfWork.CompanyRepository.GetById(request.Id);
            var response = new UnLockCompanyResponse();
            if(!company.Enable || company != null)
            {
                company.Enable = true;
                response.IsSuccess = true;
                _unitOfWork.CompanyRepository.Update(company);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                response.ErrorMessage = "Company is not existed";
            }
            return response;
        }
    }
}
