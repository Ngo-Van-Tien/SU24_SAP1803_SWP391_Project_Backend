using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;
using SWPApi.Application.Product.Responses;

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
            var response = new AddMilkBrandResponse();

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

            var milkBrand = new Infrastructure.Entities.MilkBrand
            {
                Name = request.Name,
                Description = request.Description,
                Image = image,
                Enable = true,
            };
            
            milkBrand.Company = _unitOfWork.CompanyRepository.GetById(request.CompanyId);
 
            if(milkBrand.Company == null || !milkBrand.Company.Enable)
            {
                response.ErrorMessage = "Company is not found";
                return response;
            }

            _unitOfWork.MilkBrandRepository.Add(milkBrand);
            await _unitOfWork.SaveChangesAsync();
            response.MilkBrand = milkBrand;
            response.IsSuccess = true;
            return response;
        }
    }
}
