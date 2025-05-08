namespace WISSEN.EDA.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICommonRepository CommonRepository { get; }
        IMasterRepository MasterRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IUserRepository UserRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IRoleRepository RoleRepository { get; }
        IRolePrivilegeRepository RolePrivilegeRepository { get; }
        IPrivilegeRepository PrivilegeRepository { get; }
        Task<int> SaveAsync();



    }
}
