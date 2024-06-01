using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.MilkBrand.Commands;
using SWPApi.Application.MilkBrand.Responses;

namespace SWPApi.Application.MilkBrand.Handlers
{
    public class DeleteMilkBrandHandler : IRequestHandler<DeleteMilkBrandCommand, DeleteMilkBrandResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public DeleteMilkBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteMilkBrandResponse> Handle(DeleteMilkBrandCommand request, CancellationToken cancellationToken)
        {
            var milkBrand = await _unitOfWork.MilkBrandRepository.GetById(request.Id);
            var response = new DeleteMilkBrandResponse();
            if (milkBrand == null)
            {
                response.ErrorMessage = "Milk brand is not found";
                return response;    
            }

            await _unitOfWork.MilkBrandRepository.DeleteMilkBrand(milkBrand);
            await _unitOfWork.SaveChangesAsync();
            response = _mapper.Map<DeleteMilkBrandResponse>(milkBrand);
            response.IsSuccess = true;
            return response;

        }
    }
}
