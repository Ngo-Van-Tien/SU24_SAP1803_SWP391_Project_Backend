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

        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllMilkFunctionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }
        public async Task<GetAllMilkFunctionResponse> Handle(GetAllMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllMilkFunctionResponse();
            
                var milkFunctions = _unitOfWork.MilkFunctionRepository.Find(mf => mf.Enable).ToList();
                if (!milkFunctions.Any())
                {
                    response.ErrorMessage = "Do not have any milk function";
                }
                else
                {
                    response.Data = milkFunctions;
                    response.IsSuccess = true;
                }
                
            
            return response;
        }
    }
}
