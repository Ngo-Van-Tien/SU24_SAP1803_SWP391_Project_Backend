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
            try
            {
                var company = _unitOfWork.CompanyRepository.GetById(request.Id);
                if(company == null)
                {
                    response.ErrorMessage = "Company is not found";
                }
                else
                {
                    response = _mapper.Map<GetByIdResponse>(company);
                    response.IsSuccess = true;
                }
            }catch(Exception ex)
            {
                response.ErrorMessage += ex.Message;
            }
            return response;
        }
    }
}
