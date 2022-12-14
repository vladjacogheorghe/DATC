using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;
namespace WebAPI.Repositories
{
    public interface IPlantsRepository<T> where T : PlantEntity, new()
    {
        Task<List<T>> GetAll();
        Task<T> Get(string plantId);
        Task Insert(T item);
        Task Update(T item);
        Task Delete(string plantId);

    }
}