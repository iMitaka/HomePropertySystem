namespace HomePropertySystem.Data.Repositories
{
    public interface IUowData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }   

        int SaveChanges();
    }
}
