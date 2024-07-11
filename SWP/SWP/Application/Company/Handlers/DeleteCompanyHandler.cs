using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, DeleteCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DeleteCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteCompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteCompanyResponse();

            var company = _unitOfWork.CompanyRepository.GetById(request.Id);

            if (!company.Enable || company == null)
            {
                response.ErrorMessage = "Company not found";
                return response;
            }
            if (company.Enable)
            {
                company.Enable = false;
                _unitOfWork.CompanyRepository.Update(company);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<DeleteCompanyResponse>(company);
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "Company has been deleted";
            }
            return response;

        }
    }
}
