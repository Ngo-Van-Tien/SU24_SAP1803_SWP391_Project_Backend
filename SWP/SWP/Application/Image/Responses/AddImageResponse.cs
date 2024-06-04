using Infrastructure.Models;

namespace SWPApi.Application.Image.Responses
{
    public class AddImageResponse : BaseResponse
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
    }
}
