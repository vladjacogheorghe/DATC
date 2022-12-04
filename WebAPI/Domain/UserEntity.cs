using Microsoft.WindowsAzure.Storage.Table;
namespace WebAPI.Domain
{
    public class UserEntity : TableEntity
    {
        // public UserType Type { get; set; }  //partitionKey
        // public string UserId { get; set; } //rowKey
        public string Type { get; set; } //type
        public string UserId { get; set; } //userId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        //public List<PlantEntity> listOfAllergicPlants;

        public UserEntity() { }
        public UserEntity(UserType type, string userId, string firstName, string lastName, string email, DateTime registrationDate)
        {
            PartitionKey = type.ToString();
            RowKey = userId;
            Type = PartitionKey;
            UserId = RowKey;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            if (registrationDate != null)
            {
                RegistrationDate = registrationDate;
            }
            else RegistrationDate = DateTime.Now;
            Console.Out.Write(ToString());
        }

        public string ToString()
        {
            return "PartitionKey" + PartitionKey + " " + "RowKey" + RowKey + " " +  "FirstName" + FirstName + " " +
            "LastName" + LastName + " " + "Email" + Email + " " + "RegistrationDate" + RegistrationDate + " ";
        }

    }
}