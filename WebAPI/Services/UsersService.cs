using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Repositories;
namespace WebAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository<UserEntity> repository;

        public UsersService(IUsersRepository<UserEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            return await this.repository.GetAll();
        }

        public async Task<List<UserEntity>> GetUsersByType(string type)
        {
            return await this.repository.GetAllByType(type);
        }
        public async Task<UserEntity> GetUser(string type, string userId)
        {
            return await this.repository.Get(type, userId);
        }

        public async Task AddUser(UserEntity item)
        {
            await this.repository.Insert(item);
        }

        public async Task UpdateUser(UserEntity item)
        {
            var user = await GetUser(item.PartitionKey, item.RowKey);
            if (user != null)
            {
                item.RegistrationDate = user.RegistrationDate;

                await this.repository.Update(item);
            }
        }

        public async Task DeleteUser(string type, string userId)
        {
            await this.repository.Delete(type, userId);
        }

        public async Task<bool> UserExists(string type, string userId)
        {
            return await this.repository.Get(type, userId) != null;
        }
    }
}