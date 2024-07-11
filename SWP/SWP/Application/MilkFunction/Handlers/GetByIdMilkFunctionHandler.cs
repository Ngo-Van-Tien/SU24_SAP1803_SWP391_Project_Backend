using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Handlers
{
    public class GetByIdMilkFunctionHandler : IRequestHandler<GetByIdMilkFunctionCommand, GetByIdMilkFunctionResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetByIdMilkFunctionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetByIdMilkFunctionResponse> Handle(GetByIdMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByIdMilkFunctionResponse();
            
                var milkFunction = _unitOfWork.MilkFunctionRepository.GetById(request.Id);
                if(milkFunction == null || !milkFunction.Enable)
                {
                    response.ErrorMessage = "Milk Function is not found";
                }
                else
                {
                response.MilkFunction = milkFunction;
                    response.IsSuccess = true;
                }
            
            return response;
        }
    }
}
