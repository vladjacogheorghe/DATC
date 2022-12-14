using Microsoft.WindowsAzure.Storage.Table;
namespace WebAPI.Domain
{
    public class PlantEntity : TableEntity
    {
        #nullable enable
        public string? Name { get; set; }

        public PlantEntity() { }
        public PlantEntity(string plantId, string name)
        {
            PartitionKey = plantId;
            RowKey = plantId;
            Name = name;
        }

    }
}