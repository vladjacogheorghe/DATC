using WebAPI.Domain;
using WebAPI.Repositories;
using WebAPI.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace WebAPI
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(
            IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IUsersRepository<UserEntity>>(factory =>
            {
                return new UsersRepository<UserEntity>(
                    new AzureTableSettings(
                        // storageAccount: Configuration["Table_StorageAccount"],
                        // storageKey: Configuration["Table_StorageKey"],
                        connectionString: Configuration["ConnectionString"]
                        // tableName: Configuration["Table_TableName"]
                        ));
            });
            services.AddScoped<IUsersService, UsersService>();

            // services.AddMvc(MvcOptions.EnableEndpointRouting = false);
        }
        public void Configure(
           IApplicationBuilder app,
           Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            // app.UseMvcWithDefaultRoute();
            // if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            // app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // app.MapControllers();

            // app.Run();

        }
    }
}