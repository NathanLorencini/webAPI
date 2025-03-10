using crudNET.Models;
using Microsoft.EntityFrameworkCore;

namespace crudNET.Data
{
    public class SystemTasksDbContext : DbContext
    {
        public SystemTasksDbContext(DbContextOptions<SystemTasksDbContext> options):base(options)
        {
        }

        public DbSet<UserModel> Users{ get; set; }
        public DbSet<TasksModel> Tasks{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
         base.OnModelCreating(modelBuilder);
        }
    }
}
