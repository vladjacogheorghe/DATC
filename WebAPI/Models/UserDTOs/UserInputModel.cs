using System;
using Microsoft.WindowsAzure.Storage.Table;
namespace WebAPI.Models
{
    public class UserInputModel
    {
#nullable disable
        public string Type { get; set; }  //partitionKey
        public string UserId { get; set; } //rowKey

#nullable enable
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}