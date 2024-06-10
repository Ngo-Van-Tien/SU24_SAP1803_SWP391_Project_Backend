using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.MilkFunction.Commands;
using SWPApi.Application.MilkFunction.Responses;
using System.Net.WebSockets;

namespace SWPApi.Application.MilkFunction.Handlers
{
    public class AddMilkFunctionHandler : IRequestHandler<AddMilkFunctionCommand, AddMilkFunctionResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AddMilkFunctionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddMilkFunctionResponse> Handle(AddMilkFunctionCommand request, CancellationToken cancellationToken)
        {
            var response = new AddMilkFunctionResponse();
            try
            {
                var milkFunction = new Infrastructure.Entities.MilkFunction
                {
                    Name = request.MilkFunctionName,
                };


                if (milkFunction != null)
                {
                    _unitOfWork.MilkFunctionRepository.Add(milkFunction);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<AddMilkFunctionResponse>(milkFunction);
                    response.IsSuccess = true;
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Error when creating new milk function: " + ex.Message;
            }
            return response;
        }
    }
}
