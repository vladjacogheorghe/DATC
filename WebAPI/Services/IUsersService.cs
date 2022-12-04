using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Services
{
    public interface IUsersService
    {
        Task AddUser(UserEntity item);
        Task DeleteUser(string type, string userId);
        Task<UserEntity> GetUser(string type, string userId);
        Task<List<UserEntity>> GetUsers();
        Task<List<UserEntity>> GetUsersByType(string type);
        Task<bool> UserExists(string type, string userId);
        Task UpdateUser(UserEntity item);
    }
}