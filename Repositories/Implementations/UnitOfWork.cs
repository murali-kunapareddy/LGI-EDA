
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        public ICommonRepository CommonRepository { get; private set; }
        public IMasterRepository MasterRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            CommonRepository = new CommonRepository(_dbContext);
            MasterRepository = new MasterRepository(_dbContext);
            CompanyRepository = new CompanyRepository(_dbContext);
            CustomerRepository = new CustomerRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
        }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
