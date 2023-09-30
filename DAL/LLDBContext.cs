using BOL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL
{
    public class LLDBContext : IdentityDbContext
    {
        //public LLDBContext(DbContextOptions<LLDBContext> options) : base(options)
        //{
        //    Database.Migrate();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=T480S;Database=LLDB;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           

            builder.Entity<Follow>()                                            //  1.
                .HasKey(k => new { k.FollowerId, k.FolloweeId });

            builder.Entity<Follow>()                                            //  2.
                .HasOne(u => u.Followee)
                .WithMany(u => u.Follower)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Follow>()                                            //  3.
                .HasOne(u => u.Follower)
                .WithMany(u => u.Followee)
                .HasForeignKey(u => u.FolloweeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Post>? Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }



    }
}
