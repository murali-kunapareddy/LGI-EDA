namespace WISSEN.EDA.Repositories
{
    public interface IUnitOfWork
    {
        IMasterRepository MasterRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        Task<int> SaveAsync();
    }
}
