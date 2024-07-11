using AutoMapper;
using AutoMapper.Internal.Mappers;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.Product.Responses;
using System.Runtime.InteropServices;

namespace SWPApi.Application.Company.Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UpdateCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCompanyResponse();
            
                var company = _unitOfWork.CompanyRepository.GetById(request.Id);

                if (!company.Enable || company == null)
                {
                    response.ErrorMessage = "Company not found";
                    return response;
                }

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
            if(company.Image != null)
            {
                var oldImage = company.Image;
                _unitOfWork.ImageRepository.Remove(oldImage);
                await _unitOfWork.SaveChangesAsync();
            }

            company.Name = request.Name;
            company.Description = request.Description;
            company.Nation = request.Nation;
            company.Image = image;
            company.Path = request.Path;
            

                _unitOfWork.CompanyRepository.Update(company);
                await _unitOfWork.SaveChangesAsync();

                response = _mapper.Map<UpdateCompanyResponse>(company);
                response.IsSuccess = true;
            
            
            return response;
        }
    }
}
