using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain;
using WebAPI.Repositories;
namespace WebAPI.Services
{
    public class PlantsService : IPlantsService
    {
        private readonly IPlantsRepository<PlantEntity> repository;

        public PlantsService(IPlantsRepository<PlantEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<List<PlantEntity>> GetPlants()
        {
            return await this.repository.GetAll();
        }

        public async Task<PlantEntity> GetPlant(string plantId)
        {
            return await this.repository.Get(plantId);
        }

        public async Task AddPlant(PlantEntity item)
        {
            await this.repository.Insert(item);
        }

        public async Task UpdatePlant(PlantEntity item)
        {
            if (await PlantExists(item.PartitionKey))
            {
                await this.repository.Update(item);
            }
        }

        public async Task DeletePlant(string plantId)
        {
            await this.repository.Delete(plantId);
        }

        public async Task<bool> PlantExists(string plantId)
        {
            return await this.repository.Get(plantId) != null;
        }
    }
}