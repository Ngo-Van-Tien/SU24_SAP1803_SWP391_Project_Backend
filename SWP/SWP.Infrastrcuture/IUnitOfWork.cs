using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IMilkBrandRepository MilkBrandRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IMilkFunctionRepository MilkFunctionRepository { get; }
        INutrientRepository NutrientRepository { get; }
        IProductItemRepository ProductItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IAppUserRepository AppUserRepository { get;}
        IPaymentRepository PaymentRepository { get; }
        IImageRepository ImageRepository { get; }
        IMilkBrandFunctionRepository MilkBrandFunctionRepository { get; }
        Task SaveChangesAsync();
    }
}
