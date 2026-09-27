using Cw48_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw48_2.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> db) : base(db) { }

        public DbSet<UserEntity> Users { get; set; }
    }
}
