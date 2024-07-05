using MediatR;
using SWPApi.Application.Order.Responses;

namespace SWPApi.Application.Order.Commands
{
    public class Top5ProductHightestSaleCommand : IRequest<Top5ProductHightestSaleResponse>
    {
    }
}
