using AutoMapper;
using Infrastructure;


using Infrastructure.Entities;

using MediatR;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Handlers
{
    public class GetAllMilkFunctionHandler : IRequestHandler<GetAllMilkFunctionCommand, GetAllMilkFunctionResponse>
    {

        IUnitOfWork unitOfWork;
        IMapper mapper;
        public GetAllMilkFunctionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
        public async Task<GetAllMilkFunctionResponse> Handle(GetAllMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllMilkFunctionResponse();
            try
            {

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
