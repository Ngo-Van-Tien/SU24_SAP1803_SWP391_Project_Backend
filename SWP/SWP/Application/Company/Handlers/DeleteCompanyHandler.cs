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
            var company = await _unitOfWork.CompanyRepository.GetById(request.Id);
            var response = new DeleteCompanyResponse();
            if(company == null)
            {
                response.ErrorMessage = "Company is not found";
                return response;
            }

            await _unitOfWork.CompanyRepository.DeleteCompany(company);
            await _unitOfWork.SaveChangesAsync();
            response = _mapper.Map<DeleteCompanyResponse>(company);
            response.IsSuccess = true;
            return response; 
        }
    }
}
