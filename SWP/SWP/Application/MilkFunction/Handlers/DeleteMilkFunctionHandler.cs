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
            var response = new DeleteMilkFunctionResponse();
            
                var milkFunction = _unitOfWork.MilkFunctionRepository.GetById(request.Id);
                if (milkFunction != null)
                {
                    _unitOfWork.MilkFunctionRepository.Remove(milkFunction);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<DeleteMilkFunctionResponse>(milkFunction);
                    response.IsSuccess = true;

                }
                else
                {
                    response.ErrorMessage = "Milk Function is not found";
                    return response;
                }
                
            
            return response;
        }
    }
}
