using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class FindingsService : IFindingsService
    {
        private readonly IFindingsRepository<FindingEntity> repository;

        public FindingsService(IFindingsRepository<FindingEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<List<FindingEntity>> GetFindings()
        {
            return await this.repository.GetAll();
        }

        public async Task<List<FindingEntity>> GetFindingsByType(string plantId)
        {
            return await this.repository.GetAllByPlantId(plantId);
        }
        public async Task<FindingEntity> GetFinding(string plantId, string findingId)
        {
            return await this.repository.Get(plantId, findingId);
        }

        public async Task AddFinding(FindingEntity item)
        {
            await this.repository.Insert(item);
        }

        public async Task UpdateFinding(FindingEntity item)
        {
            var finding = await GetFinding(item.PartitionKey, item.RowKey);
            if (finding != null)
            {
                foreach (var property in item.GetType().GetProperties())
                {
                    if (property.GetValue(item) != null)
                    {
                        property.SetValue(finding, property.GetValue(item));
                    }
                }
                await this.repository.Update(finding);
            }
        }

        public async Task DeleteFinding(string plantId, string findingId)
        {
            await this.repository.Delete(plantId, findingId);
        }

        public async Task<bool> FindingExists(string plantId, string findingId)
        {
            return await this.repository.Get(plantId, findingId) != null;
        }
    }
}