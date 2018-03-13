namespace HomePropertySystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DbContextFactory : IDesignTimeDbContextFactory<HomesDbContext>
    {
        HomesDbContext IDesignTimeDbContextFactory<HomesDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HomesDbContext>();
            optionsBuilder.UseSqlServer(DbContextConstants.GetConnectionString());

            return new HomesDbContext(optionsBuilder.Options);
        }
    }
}
