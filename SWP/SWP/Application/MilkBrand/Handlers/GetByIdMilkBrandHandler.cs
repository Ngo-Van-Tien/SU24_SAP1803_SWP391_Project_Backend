using AutoMapper;
using Infrastructure;
using Infrastructure.Models;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class GetByIdMilkBrandHandler : IRequestHandler<GetByIdMilkBrandCommand, GetByIdMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public GetByIdMilkBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetByIdMilkBrandResponse> Handle(GetByIdMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new GetByIdMilkBrandResponse();
            try
            {
                var milkBrand = _unitOfWork.MilkBrandRepository.GetById(request.Id);
                if(milkBrand == null)
                {
                    response.ErrorMessage = "Milk Brand is not found";
                }
                else
                {
                    response = _mapper.Map<GetByIdMilkBrandResponse>(milkBrand);
                    response.IsSuccess = true;
                }
            }catch (Exception ex)
            {
                response.ErrorMessage += ex.Message;
            }
            return response;
        }
    }
}
