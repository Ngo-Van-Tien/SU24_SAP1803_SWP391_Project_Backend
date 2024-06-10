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
                var milkFunction = unitOfWork.MilkFunctionRepository.GetAll();
                if (!milkFunction.Any())
                {
                    response.ErrorMessage = "Don't have any Milk Function";
                    response.IsSuccess = false;
                    return response;
                }
                response.MilkFunction = mapper.Map<List<Infrastructure.Entities.MilkFunction>>(milkFunction);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error when creating new function: " + ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
