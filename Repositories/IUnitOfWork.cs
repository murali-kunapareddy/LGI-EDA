namespace WISSEN.EDA.Repositories
{
    public interface IUnitOfWork
    {
        ICommonRepository CommonRepository { get; }
        IMasterRepository MasterRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        Task<int> SaveAsync();
    }
}
