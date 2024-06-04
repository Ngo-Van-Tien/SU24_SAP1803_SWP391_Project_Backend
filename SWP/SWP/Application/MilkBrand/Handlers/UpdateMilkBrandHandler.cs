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
            var milkBrand = await _unitOfWork.MilkBrandRepository.GetById(request.Id);
            var response = new UpdateMilkBrandResponse();
            if(milkBrand == null)
            {
                response.ErrorMessage = "Milk brand is not found";
                return response;
            }

            var company = await _unitOfWork.CompanyRepository.GetById(request.CompanyId.Value);
            if(company == null)
            {
                response.ErrorMessage = "Company is not existing";
                return response;
            }else if (request.CompanyId.Value.Equals("")){
                company = null;
            }

            milkBrand.Name = request.Name;
            milkBrand.Description = request.Description;
            milkBrand.Company = company;

            await _unitOfWork.MilkBrandRepository.UpdateMilkBrand(milkBrand);
            await _unitOfWork.SaveChangesAsync();
            response = _mapper.Map<UpdateMilkBrandResponse>(milkBrand);
            response.IsSuccess = true;
            return response;


        }
    }
}
