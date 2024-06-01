using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Handlers
{
    public class UpdateMilkFunctionHandler : IRequestHandler<UpdateMilkFunctionCommand, UpdateMilkFunctionResponse>
    {
        IUnitOfWork _unitOfOfWork;
        IMapper _mapper;

        public UpdateMilkFunctionHandler(IUnitOfWork unitOfOfWork, IMapper mapper)
        {
            _unitOfOfWork = unitOfOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateMilkFunctionResponse> Handle(UpdateMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var milkFunction = await _unitOfOfWork.MilkFunctionRepository.GetById(request.Id);
            var response = new UpdateMilkFunctionResponse();
            if(milkFunction != null)
            {
                milkFunction.MilkFunctionName = request.MilkFunctionName;
                await _unitOfOfWork.MilkFunctionRepository.UpdateMilkFunction(milkFunction);
                await _unitOfOfWork.SaveChangesAsync();
                response = _mapper.Map<UpdateMilkFunctionResponse>(milkFunction);
                response.IsSuccess = true;
                return response;
            }
            response.ErrorMessage = "Milk Function is not found";
            return response;

        }
    }
}
