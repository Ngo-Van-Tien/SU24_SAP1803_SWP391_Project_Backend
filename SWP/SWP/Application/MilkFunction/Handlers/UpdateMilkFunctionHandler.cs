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
            var response = new UpdateMilkFunctionResponse();
            try
            {
                var milkFunction = _unitOfOfWork.MilkFunctionRepository.GetById(request.Id);
                
                if (milkFunction != null)
                {
                    milkFunction.Name = request.Name;

                    _unitOfOfWork.MilkFunctionRepository.Update(milkFunction);
                    await _unitOfOfWork.SaveChangesAsync();
                    response = _mapper.Map<UpdateMilkFunctionResponse>(milkFunction);

                    response.IsSuccess = true;
                    return response;
                }
                else
                {
                    response.ErrorMessage = "Milk Function is not found";
                    return response;
                }
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Error when update milk function: " + ex.Message;
            }
            return response;
        }
    }
}
