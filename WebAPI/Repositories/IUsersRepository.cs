using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
namespace WebAPI.Repositories
{
    public interface IUsersRepository<T> where T : UserEntity, new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByType(string type);
        Task<T> Get(string type, string userId);
        Task Insert(T item);
        Task Update(T item);
        Task Delete(string type, string userId);

    }
}