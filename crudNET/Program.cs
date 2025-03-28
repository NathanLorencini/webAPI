
using crudNET.Data;
using crudNET.Repositories;
using crudNET.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crudNET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add DataBase
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SystemTasksDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddScoped<IUserRepositorie, UserRepositorie>(); // injecao de dependencia, toda vez q chamar IUserRe.. vai vai buildar a UserRe

            //builder.Services.AddDbContext<SystemTasksDbContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
