using Infrastructure;
using MediatR;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.Company.Responses;

namespace SWPApi.Application.Company.Handlers
{
    public class GetProductByCompanyHandler : IRequestHandler<GetProductByCompanyCommand, GetProductByCompanyResponse>
    {
        IUnitOfWork _unitOfWork;
        public GetProductByCompanyHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public async Task<GetProductByCompanyResponse> Handle(GetProductByCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new GetProductByCompanyResponse();
            var company = _unitOfWork.CompanyRepository.GetById(request.Id);
            if (company == null || !company.Enable)
            {
                response.ErrorMessage = "Company is not existed";
                return response;
            }
            var products = _unitOfWork.ProductItemRepository.Find(p => p.Product.MilkBrand.Company.Id == request.Id).ToList();

            response.Data = products;
            response.IsSuccess = true;
            return response;
        }
    }
}
