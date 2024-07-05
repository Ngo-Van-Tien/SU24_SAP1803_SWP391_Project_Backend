using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class Top5ProductLeaestSaleCommand : IRequest<Top5ProductLeaestSaleResponse>
    {
    }
}
