using WebAPI.Domain;

namespace WebAPI.Services
{
    public interface IFindingsService
    {
        Task<List<FindingEntity>> GetFindings();
        Task<List<FindingEntity>> GetFindingsByType(string plantId);
        Task<FindingEntity> GetFinding(string plantId, string findingId);
        Task AddFinding(FindingEntity item);
        Task<bool> FindingExists(string plantId, string findingId);
        Task UpdateFinding(FindingEntity item);
        Task DeleteFinding(string plantId, string findingId);
    }
}