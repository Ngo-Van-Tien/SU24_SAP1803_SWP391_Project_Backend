﻿using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class AddMilkBrandHandler : IRequestHandler<AddMilkBrandCommand, AddMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AddMilkBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddMilkBrandResponse> Handle(AddMilkBrandCommand request, CancellationToken cancellationToken)
        {

            var milkBrand = new Infrastructure.Entities.MilkBrand
            {
                Name = request.Name,
                Description = request.Description,
            };
            var response = new AddMilkBrandResponse();
            if (request.CompanyId.HasValue)
            {
                milkBrand.Company = await _unitOfWork.CompanyRepository.GetById(request.CompanyId.Value);
            }
            if(milkBrand != null)
            {
                await _unitOfWork.MilkBrandRepository.AddMilkBrand(milkBrand);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<AddMilkBrandResponse>(milkBrand);
                response.IsSuccess = true;
                return response;
            }
            response.ErrorMessage = "Error when create new brand";
            return response;
        }
    }
}
