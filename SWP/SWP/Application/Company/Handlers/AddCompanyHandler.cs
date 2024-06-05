using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, AddCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AddCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddCompanyResponse> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new AddCompanyResponse();

            try
            {
                var company = new Infrastructure.Entities.Company
                {
                    Name = request.Name,
                    Description = request.Description,
                    Nation = request.Nation,
                };

                await _unitOfWork.CompanyRepository.AddCompany(company);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<AddCompanyResponse>(company);

                if (company != null)
                {
                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    response.ErrorMessage = "Error when creating a new company";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = $"An error occurred: {ex.Message}";
                return response;
            }
        }
    }
}
