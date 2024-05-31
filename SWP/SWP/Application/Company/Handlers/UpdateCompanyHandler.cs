using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;
using System.Runtime.InteropServices;

namespace SWPApi.Application.Company.Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UpdateCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {

            var company = await _unitOfWork.CompanyRepository.GetById(request.Id);
            var response = new UpdateCompanyResponse();
            if(company == null) 
            {
                response.ErrorMessage = "Company is not found";
                return response;
            }
            company.Name = request.Name;
            company.Description = request.Description;
            company.Nation = request.Nation;

            await _unitOfWork.CompanyRepository.UpdateCompany(company);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            return response;
        }
    }
}
