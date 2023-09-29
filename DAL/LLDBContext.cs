using BOL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LLDBContext : IdentityDbContext
    {
        public LLDBContext(DbContextOptions<LLDBContext> options) : base(options)
        {
            Database.Migrate();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-MSQQ9TJ\SQLEXPRESS01;Database=LLDb;Trusted_Connection=True;");
        //}

        public DbSet<Post>? Posts { get; set; }
    }
}
