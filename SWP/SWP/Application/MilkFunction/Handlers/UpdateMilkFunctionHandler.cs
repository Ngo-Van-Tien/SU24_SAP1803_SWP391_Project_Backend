﻿using AutoMapper;
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
            
                var milkFunction = _unitOfOfWork.MilkFunctionRepository.GetById(request.Id);
                
                if (milkFunction != null && milkFunction.Enable)
                {
                    milkFunction.Name = request.Name;

                    _unitOfOfWork.MilkFunctionRepository.Update(milkFunction);
                    await _unitOfOfWork.SaveChangesAsync();
                    response.MilkFunction = milkFunction;
                    response.IsSuccess = true;
                    
                }
                else
                {
                    response.ErrorMessage = "Milk Function is not found";
                    
                }
                
            
            return response;
        }
    }
}
