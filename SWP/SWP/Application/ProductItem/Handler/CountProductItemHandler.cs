using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using SWPApi.Application.Company.Commands;
using SWPApi.Application.ProductItem.Commands;
using SWPApi.Application.ProductItem.Response;

namespace SWPApi.Application.ProductItem.Handler
{
    public class CountProductItemHandler : IRequestHandler<CountProductItemCommand, CountProductItemResponse>
    {
        IUnitOfWork _unitOfWork;
        public CountProductItemHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CountProductItemResponse> Handle(CountProductItemCommand request, CancellationToken cancellationToken)
        {
            var count = _unitOfWork.ProductItemRepository.GetAll()
                               .Count(item => item.Enable);

            var response = new CountProductItemResponse
            {
                IsSuccess = true,
                Quantity = count
            };

            return response;
        }
    }
}
