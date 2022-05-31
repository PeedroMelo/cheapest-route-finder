using BestCostRouteFinder.Application.Services;
using BestCostRouteFinder.Application.UseCases.V1.RouteCostFinder;
using BestCostRouteFinder.Application.UseCases.V1.RouteOperations;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using BestCostRouteFinder.Domain.Interfaces;
using BestCostRouteFinder.Infrastructure.EFCoreDataAccess.Context;
using BestCostRouteFinder.Infrastructure.EFCoreDataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BestCostRouteFinder.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IRouteCalulatorService, RouteCalculatorService>();
            
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IRouteRepository, RouteRepository>();
            #endregion

            #region UseCases
            services.AddTransient<IRouteOperations, RouteOperations>();
            services.AddTransient<IRouteCostFinder, RouteCostFinder>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BestCostRouteFinder.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BestCostRouteFinder.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
