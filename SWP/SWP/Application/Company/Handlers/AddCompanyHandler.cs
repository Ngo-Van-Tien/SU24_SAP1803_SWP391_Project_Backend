using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, AddCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AddCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddCompanyResponse> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new AddCompanyResponse();

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


            var company = new Infrastructure.Entities.Company
            {
                Name = request.Name,
                Description = request.Description,
                Nation = request.Nation,
                Image = image,
                Path = request.Path,
                Enable = true
                };

                _unitOfWork.CompanyRepository.Add(company);
                await _unitOfWork.SaveChangesAsync();
                response.Company = company;
                response.IsSuccess = true;

                return response;
            
        }
    }
}
