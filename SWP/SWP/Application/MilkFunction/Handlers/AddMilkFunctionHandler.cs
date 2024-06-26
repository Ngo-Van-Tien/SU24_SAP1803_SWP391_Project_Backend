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
            
                var milkFunction = new Infrastructure.Entities.MilkFunction
                {
                    Name = request.Name,
                };


                if (milkFunction != null)
                {
                    _unitOfWork.MilkFunctionRepository.Add(milkFunction);
                    await _unitOfWork.SaveChangesAsync();
                    response = _mapper.Map<AddMilkFunctionResponse>(milkFunction);
                    response.IsSuccess = true;
                }


            
            return response;
        }
    }
}
