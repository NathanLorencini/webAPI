using crudNET.Data.Map;
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
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TasksMap());
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLSERVER2022;Database=webapi;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

    }
}
