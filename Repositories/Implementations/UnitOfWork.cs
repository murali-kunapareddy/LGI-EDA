
using Microsoft.EntityFrameworkCore;

using WISSEN.EDA.Data;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        private readonly HttpContextAccessor _httpContextAccessor;
        private bool disposed = false;

        public ICommonRepository CommonRepository { get; private set; }
        public IMasterRepository MasterRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IUserRepository UserRepository { get; set; }
        public IUserProfileRepository UserProfileRepository { get; set; }
        public IUserRoleRepository UserRoleRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public IRolePrivilegeRepository RolePrivilegeRepository { get; set; }
        public IPrivilegeRepository PrivilegeRepository { get; set; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            CommonRepository = new CommonRepository(_dbContext);
            MasterRepository = new MasterRepository(_dbContext);
            CompanyRepository = new CompanyRepository(_dbContext);
            CustomerRepository = new CustomerRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
            OrderRepository = new OrderRepository(_dbContext);
            UserRepository = new UserRepository(_dbContext);
            UserProfileRepository = new UserProfileRepository(_dbContext);
            UserRoleRepository = new UserRoleRepository(_dbContext);
            RoleRepository = new RoleRepository(_dbContext);
            RolePrivilegeRepository = new RolePrivilegeRepository(_dbContext);
            PrivilegeRepository = new PrivilegeRepository(_dbContext);
        }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _dbContext.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
