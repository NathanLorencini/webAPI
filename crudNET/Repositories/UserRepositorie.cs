using crudNET.Data;
using crudNET.Models;
using crudNET.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crudNET.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly SystemTasksDbContext dbContext;
        public UserRepositorie(SystemTasksDbContext systemTasksDbContext)
        {
            dbContext = systemTasksDbContext;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await dbContext.Users.AddAsync(user);
            dbContext.SaveChanges();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await GetUserById(id);
            
            if (userToDelete is null)
                throw new Exception("This User does not exist");

            dbContext.Users.Remove(userToDelete);
            dbContext.SaveChanges();
            return true;
        }

        public Task<List<UserModel>> GetAllUser()
        {
           return dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            var userToUpdate = await GetUserById(id);
            
            if (userToUpdate is null)
                throw new Exception("This User does not exist");

            userToUpdate.Email = user.Email;
            userToUpdate.Name = user.Name;

            dbContext.Users.Update(userToUpdate);
            dbContext.SaveChanges();
            
            return userToUpdate;
        }
    }
}
