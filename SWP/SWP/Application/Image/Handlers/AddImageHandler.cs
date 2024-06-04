using AutoMapper;
using Infrastructure;
using MediatR;
using SWPApi.Application.Image.Commands;
using SWPApi.Application.Image.Responses;

namespace SWPApi.Application.Image.Handlers
{
    public class AddImageHandler : IRequestHandler<AddImageCommand, AddImageResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AddImageHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddImageResponse> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
