using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using SWPApi.Application.Product.Commands;
using SWPApi.Application.Product.Responses;

namespace SWPApi.Application.Product.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public AddProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            ImageFile image = null;
            var response = new AddProductResponse();
            if (request.Image != null && request.Image.Length > 0)
            {

                using (var stream = new MemoryStream())
                {
                    await request.Image.CopyToAsync(stream);
                    image = new ImageFile() { Content = stream.ToArray() };
                    _unitOfWork.ImageRepository.Add(image);
                }
            }
            //create Entity
            var product = new Infrastructure.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                StartAge = request.StartAge,
                EndAge = request.EndAge,
                Image = image
            };

            
            product.MilkBrand = _unitOfWork.MilkBrandRepository.GetById(request.MilkBrandId);
            

            if (product.MilkBrand == null) 
            {
                response.ErrorMessage = "The MilkBrand isn't found";
                return response;
            }

            foreach (var nutrientDetail in request.Nutrients)
            {
                var nutrient = _unitOfWork.NutrientRepository.GetById(nutrientDetail.NutrientId);
                if (nutrient != null)
                {
                    var productNutrient = new ProductNutrient
                    {
                        Product = product,
                        Nutrient = nutrient,
                        In100g = nutrientDetail.In100g,
                        InCup = nutrientDetail.InCup,
                        Unit = nutrientDetail.Unit
                    };
                    _unitOfWork.ProductNutrientRepository.Add(productNutrient);
                }
            }


            if (product != null)
            {
                _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.SaveChangesAsync();
                response = _mapper.Map<AddProductResponse>(product);
                response.IsSuccess = true;
                return response;
            }

            response.ErrorMessage = "Error at adding product";
            return response;
        }
    }
}