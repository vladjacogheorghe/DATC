using WebAPI.Domain;
using WebAPI.Repositories;
using WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

    }
}
// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.

// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<IUsersRepository<UserEntity>>(factory =>
//             {
//                 return new UsersRepository<UserEntity>(
//                     new AzureTableSettings(
//                         storageAccount: Configuration["Table_StorageAccount"],
//                         storageKey: Configuration["Table_StorageKey"]
//                         // tableName: Configuration["Table_TableName"]
//                         ));
//             }
// builder.Services.AddScoped<IUsersService, UsersService>();

// builder.Services.AddMvc();


// var app = builder.Build();

// // Configure the HTTP request pipeline.
// // if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/swagger.json", "Ambrozia Alert"));
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
