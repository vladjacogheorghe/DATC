using WebAPI.Domain;
namespace WebAPI.Repositories
{
    public interface IFindingsRepository<T> where T : FindingEntity, new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllByPlantId(string plantId);
        Task<T> Get(string plantId, string findingId);
        Task Insert(T item);
        Task Update(T item);
        Task Delete(string plantId, string findingId);

    }
}