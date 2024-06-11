using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.Design.Serialization;

namespace SWPApi.Application.Company.Handlers
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyCommand, GetAllCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllCompanyResponse> Handle(GetAllCompanyCommand request, CancellationToken cancellationToken)
        {
            var companies = _unitOfWork.CompanyRepository.GetAll();
            var response = new GetAllCompanyResponse();

            if (!companies.Any())
            {
                response.ErrorMessage = "Do not have any company";
                response.IsSuccess = false;
            }
            else
            {
                response.Companies = companies.ToList();
                response.IsSuccess = true;
            }

            return response;
        }
    }
}
