using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SWPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly ISender _mediator;
        public ProductItemController(ISender mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet] Task<IActionResult> GetProductItemByID(Guid id)
        {
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        Task<IActionResult> UpdateProductItem(Guid id)
        {
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        Task<IActionResult> DeleteProductItem(Guid id)
        {
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        Task<IActionResult> GetAllProductItm()
        {
            return null;
        }
    }
}
