using Microsoft.WindowsAzure.Storage.Table;
namespace WebAPI.Domain
{
    public class UserEntity : TableEntity
    {
        // public string Type { get; set; } ///partitionKey
        // public string UserId { get; set; } //rowKey
#nullable enable
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime RegistrationDate { get; set; }

        // public List<string> listOfAllergicPlantIds;
        public UserEntity() { }
        public UserEntity(UserType type, string userId, string firstName, string lastName, string email, double? latitude, double? longitude, DateTime registrationDate)
        {
            PartitionKey = type.ToString();
            RowKey = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            // if (latitude != null)
            // {
            Latitude = latitude;
            // }
            // if (longitude != null)
            // {
            Longitude = longitude;
            // }
            if (registrationDate != new DateTime())
            {
                RegistrationDate = registrationDate;
            }
            else RegistrationDate = DateTime.Now;
        }
    }
}