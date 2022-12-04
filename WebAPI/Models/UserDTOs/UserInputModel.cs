using Microsoft.WindowsAzure.Storage.Table;
namespace WebAPI.Models
{
    public class UserInputModel
    {
        public string? Type { get; set; }  //partitionKey
        public string? UserId { get; set; } //rowKey
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}