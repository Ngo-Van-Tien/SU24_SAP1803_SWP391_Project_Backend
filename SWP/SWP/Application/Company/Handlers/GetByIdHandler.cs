using AutoMapper;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetByIdCommand, GetByIdResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetByIdResponse> Handle(GetByIdCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByIdResponse();
            
                var company = _unitOfWork.CompanyRepository.GetById(request.Id);
                if(!company.Enable || company == null)
                {
                    response.ErrorMessage = "Company is not found";
                }
                else
                {
                    response.Company = company;
                    response.IsSuccess = true;
                }
            
            return response;
        }
    }
}
