using AutoMapper;
using AutoMapper.Internal.Mappers;
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
            var response = new UpdateCompanyResponse();
            
                var company = _unitOfWork.CompanyRepository.GetById(request.Id);

                if (company == null)
                {
                    response.ErrorMessage = "Company not found";
                    return response;
                }

                company.Name = request.Name;
                company.Description = request.Description;
                company.Nation = request.Nation;

                _unitOfWork.CompanyRepository.Update(company);
                await _unitOfWork.SaveChangesAsync();

                response = _mapper.Map<UpdateCompanyResponse>(company);
                response.IsSuccess = true;
            
            
            return response;
        }
    }
}
