using WebAPI.Domain;
using WebAPI.Repositories;
using WebAPI.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Google.Apis.Auth.AspNetCore3;
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
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddAuthentication().AddOAuth("Oauth", options =>
            {
                // When a user needs to sign in, they will be redirected to the authorize endpoint
                options.AuthorizationEndpoint = "";

                // scopes when redirecting to the authorization endpoint
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");

                options.ClientSecret = "";

            });

            AzureTableSettings azureTableSettings = new AzureTableSettings(System.Environment.GetEnvironmentVariable("ambrosiaalertAzureConnectionString"));

            services.AddScoped<IUsersRepository<UserEntity>>(factory =>
            {
                return new UsersRepository<UserEntity>(azureTableSettings);
            });
            services.AddScoped<IPlantsRepository<PlantEntity>>(factory =>
            {
                return new PlantsRepository<PlantEntity>(azureTableSettings);
            });
            services.AddScoped<IFindingsRepository<FindingEntity>>(factory =>
           {
               return new FindingsRepository<FindingEntity>(azureTableSettings);
           });

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IPlantsService, PlantsService>();
            services.AddScoped<IFindingsService, FindingsService>();

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
            app.UseCors("corsapp");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            //app.MapControllers();

            // app.Run();

        }
    }
}