﻿using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;
using System.ComponentModel.Design.Serialization;

namespace SWPApi.Application.Company.Handlers
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyCommand, GetAllCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetAllCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAllCompanyResponse> Handle(GetAllCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllCompanyResponse();
            
            var companies = _unitOfWork.CompanyRepository.Find(c => c.Enable).ToList();

            response.Data = companies;
            response.IsSuccess = true;

            return response;
        }
    }
}
