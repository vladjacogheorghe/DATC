using System.ComponentModel;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebAPI.Domain
{
    public class FindingEntity : TableEntity
    {

        // public string PlantId { get; set; } //partitionKey
        // public string FindingId { get; set; } //rowKey

        [DefaultValue(0.01)]
        public string UserId { get; set; }
        public double Radius { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public FindingEntity() { }
        public FindingEntity(string plantId, string findingId, string userId, double? radius, double latitude, double longitude)
        {
            PartitionKey = plantId;
            RowKey = findingId;
            UserId = userId;
            if (radius != null)
            {
                Radius = (double)radius;
            }
            Latitude = latitude;
            Longitude = longitude;
        }

        //TODO: method to increase radius
    }
}