using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.MilkFunction.Responses;

namespace SWPApi.Application.MilkFunction.Handlers
{
    public class DeleteMilkFunctionHandler : IRequestHandler<DeleteMilkFunctionCommand, DeleteMilkFunctionResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DeleteMilkFunctionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DeleteMilkFunctionResponse> Handle(DeleteMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var milkFunction = await _unitOfWork.MilkFunctionRepository.GetById(request.Id);
            var response = new DeleteMilkFunctionResponse();    
            if(milkFunction != null)
            {
                await _unitOfWork.MilkFunctionRepository.DeleteMilkFunction(milkFunction);
                await _unitOfWork.SaveChangesAsync(); 
                response.IsSuccess = true;
                return response;
            }
            response.ErrorMessage = "Milk Function is not found";
            return response;
        }
    }
}
