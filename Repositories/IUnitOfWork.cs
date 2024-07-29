namespace WISSEN.EDA.Repositories
{
    public interface IUnitOfWork
    {
        IMasterRepository MasterRepository { get; }
        Task<int> SaveAsync();
    }
}
