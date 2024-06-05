﻿using MediatR;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Commands
{
    public class AddMilkBrandCommand : IRequest<AddMilkBrandResponse>
    {
        public string Name { get; set; }
        public Guid? CompanyId { get; set; }
        public string? Description { get; set; }
    }
}
