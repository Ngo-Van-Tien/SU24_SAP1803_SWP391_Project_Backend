﻿using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class UpdateMilkBrandCommand : IRequest<UpdateMilkBrandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CompanyId { get; set; }
        public string? Description { get; set; }
    }
}