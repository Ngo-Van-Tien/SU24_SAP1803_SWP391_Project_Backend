using Infrastructure.IRepositories;
using Infrastructure.Repositories;
using SWP.Infrastrcuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SWPDbContext _context;
        public IProductRepository ProductRepository { get; private set; }
        public IMilkBrandRepository MilkBrandRepository {  get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }
        public IMilkFunctionRepository MilkFunctionRepository { get; private set; }
        public INutrientRepository NutrientRepository { get; private set; }
        public IProductItemRepository ProductItemRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }
        public IImageRepository ImageRepository {  get; private set; }
        public IAppUserRepository AppUserRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public IMilkBrandFunctionRepository MilkBrandFunctionRepository { get; private set; }
        public IProductNutrientRepository ProductNutrientRepository { get; private set; }
        public UnitOfWork(SWPDbContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            MilkBrandRepository = new MilkBrandRepository(_context);
            CompanyRepository = new CompanyRepository(_context);
            MilkFunctionRepository = new MilkFunctionRepository(_context);
            NutrientRepository = new NutrientRepository(_context);
            ProductItemRepository = new ProductItemRepository(_context);
            OrderRepository = new OrderRepository(_context);
            PaymentRepository = new PaymentRepository(_context);
            ImageRepository = new ImageRepository(_context);
            AppUserRepository = new AppUserRepository(_context);
            OrderDetailRepository = new OrderDetailRepository(_context);
            MilkBrandFunctionRepository = new MilkBrandFunctionRepository(_context);
            ProductNutrientRepository = new ProductNutrientRepository(_context);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
