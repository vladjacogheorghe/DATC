using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Domain;

namespace WebAPI.Services
{
    public interface IPlantsService
    {
        Task AddPlant(PlantEntity item);
        Task DeletePlant(string plantId);
        Task<PlantEntity> GetPlant(string plantId);
        Task<List<PlantEntity>> GetPlants();
        Task<bool> PlantExists(string plantId);
        Task UpdatePlant(PlantEntity item);
    }
}