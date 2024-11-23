namespace WISSEN.EDA.Repositories
{
    public interface IUnitOfWork
    {
        ICommonRepository CommonRepository { get; }
        IMasterRepository MasterRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> SaveAsync();
    }
}
