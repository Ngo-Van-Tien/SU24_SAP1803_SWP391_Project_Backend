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

           
                var company = new Infrastructure.Entities.Company
                {
                    Name = request.Name,
                    Description = request.Description,
                    Nation = request.Nation,
                };

                _unitOfWork.CompanyRepository.Add(company);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<AddCompanyResponse>(company);
                response.IsSuccess = true;

                return response;
            
        }
    }
}
