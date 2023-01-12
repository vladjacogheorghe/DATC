using WebAPI.Domain;
using System.ComponentModel;

namespace WebAPI.Models
{
    public class FindingCreateInputModel
    {
#nullable disable
        public string PlantId { get; set; } //partitionKey
        // public string FindingId { get; set; } //rowKey
        public string UserId { get; set; }
        [DefaultValue(0.01)]
        public double Radius { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}