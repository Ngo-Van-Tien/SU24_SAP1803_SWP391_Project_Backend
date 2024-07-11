using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
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
            
                var milkBrand = _unitOfWork.MilkBrandRepository.GetById(request.Id);
                
                if (milkBrand == null || !milkBrand.Enable)
                {
                    response.ErrorMessage = "Milk brand is not found";
                    return response;
                }

                var company = _unitOfWork.CompanyRepository.GetById(request.CompanyId);
                if (company == null || !company.Enable)
                {
                    response.ErrorMessage = "Company is not existing";
                    return response;
                }

                milkBrand.Name = request.Name;
                milkBrand.Description = request.Description;
                milkBrand.Company = company;
            ImageFile image = null;
            if (request.Image != null && request.Image.Length > 0)
            {

                using (var stream = new MemoryStream())
                {
                    await request.Image.CopyToAsync(stream);
                    image = new ImageFile() { Content = stream.ToArray() };
                    _unitOfWork.ImageRepository.Add(image);
                }
            }
            var oldImage = milkBrand.Image;
            if(oldImage != null)
            {
                _unitOfWork.ImageRepository.Remove(oldImage);
                await _unitOfWork.SaveChangesAsync();
            }

            milkBrand.Image = image;

            _unitOfWork.MilkBrandRepository.Update(milkBrand);
                await _unitOfWork.SaveChangesAsync();
                response.MilkBrand = milkBrand;
                response.IsSuccess = true;
                
            
            return response;
        }
    }
}
