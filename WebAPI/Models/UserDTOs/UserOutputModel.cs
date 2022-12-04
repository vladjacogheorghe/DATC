using Microsoft.WindowsAzure.Storage.Table;
using WebAPI.Domain;
namespace WebAPI.Models
{
    public class UserOutputModel
    {
        public string? Type { get; set; }  //partitionKey
        public string? UserId { get; set; } //rowKey
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        // public string PartitionKey { get; set; }
        // public string RowKey { get; set; }
        // public DateTimeOffset? Timestamp { get; set; }
    }
}