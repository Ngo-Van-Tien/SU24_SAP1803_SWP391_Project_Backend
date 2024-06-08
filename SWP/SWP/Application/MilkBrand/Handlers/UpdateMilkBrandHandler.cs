using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class UpdateMilkBrandHandler : IRequestHandler<UpdateMilkBrandCommand, UpdateMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateMilkBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateMilkBrandResponse> Handle(UpdateMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateMilkBrandResponse();
            try
            {
                var milkBrand = _unitOfWork.MilkBrandRepository.GetById(request.Id);
                
                if (milkBrand == null)
                {
                    response.ErrorMessage = "Milk brand is not found";
                    return response;
                }

                var company = _unitOfWork.CompanyRepository.GetById(request.CompanyId.Value);
                if (company == null)
                {
                    response.ErrorMessage = "Company is not existing";
                    return response;
                }

                milkBrand.Name = request.Name;
                milkBrand.Description = request.Description;
                milkBrand.Company = company;

                _unitOfWork.MilkBrandRepository.Update(milkBrand);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<UpdateMilkBrandResponse>(milkBrand);
                response.IsSuccess = true;
                return response;
            }
            catch  (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Error when creating new brand: " + ex.Message;
            }
            return response;
        }
    }
}
