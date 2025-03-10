using crudNET.Models;

namespace crudNET.Repositories.Interfaces
{
    public interface IUserRepositorie
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
