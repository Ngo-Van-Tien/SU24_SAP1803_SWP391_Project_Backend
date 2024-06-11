using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Handlers
{
    public class GetAllMilkFunctionHandler : IRequestHandler<GetAllMilkFunctionCommand, GetAllMilkFunctionResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllMilkFunctionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetAllMilkFunctionResponse> Handle(GetAllMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllMilkFunctionResponse();
            try
            {
                var milkFunctions = _unitOfWork.MilkFunctionRepository.GetAll().ToList();
                
                if(!milkFunctions.Any())
                {
                    response.ErrorMessage = "Do not have any milk function";
                    return response;
                }
                response.Data = milkFunctions;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
