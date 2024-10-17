
using WISSEN.EDA.Data;

namespace WISSEN.EDA.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        public IMasterRepository MasterRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }

        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            MasterRepository = new MasterRepository(_dbContext);
            CompanyRepository = new CompanyRepository(_dbContext);
        }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
