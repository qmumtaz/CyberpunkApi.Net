using ClientApi.Services.DataModels;

namespace ClientApi.Services
{
    public interface IUserService
    {
        Task CreateUser(User users);
        Task Delete(string id);
        User GetUserById(string id);
        Task<User?> GetUserByUsername(string username);
        Task<List<User>> GetUsers();
        Task Update(User user);
    }
}