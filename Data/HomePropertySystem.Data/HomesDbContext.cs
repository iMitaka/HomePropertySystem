namespace HomePropertySystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class HomesDbContext : IdentityDbContext<ApplicationUser>
    {
        public HomesDbContext(DbContextOptions<HomesDbContext> options)
            : base(options)
        {
        }

        //public DbSet<FriendRequest> FriendRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<FriendRequest>()
            //    .HasOne(x => x.ApplicationUser)
            //    .WithMany(x => x.FriendRequests)
            //    .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
