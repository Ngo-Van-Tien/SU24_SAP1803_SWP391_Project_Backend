using MediatR;
using SWPApi.Application.Image.Responses;

namespace SWPApi.Application.Image.Commands
{
    public class AddImageCommand : IRequest<AddImageResponse>
    {
        public string Base64Data { get; set; }
        public string FileName { get; set; }
    }
}
