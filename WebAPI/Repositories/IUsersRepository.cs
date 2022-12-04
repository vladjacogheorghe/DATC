using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
namespace WebAPI.Repositories
{
    public interface IUsersRepository<T> where T : UserEntity, new()
    {
        Task Delete(string type, string userId);
        Task<T> Get(string type, string userId);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByType(string type);
        Task Insert(T item);
        Task Update(T item);
    }
}