using System.Threading.Tasks;
using CarRental.Application;
using CarRental.Infrastructure;
using CarRental.Web.Api.GraphQL;
using CarRental.Web.Api.GraphQL.Cars;
using CarRental.Web.Api.GraphQL.Rentals;
using CarRental.Web.Configuration;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRental.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddControllers();

            services
                .AddGraphQLServer()
                .AddFiltering()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<CarType>()
                .AddType<RentalType>();

            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDbInitializer();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
                endpoints.Map("/", context =>
                {
                    context.Response.Redirect("/graphql");
                    return Task.CompletedTask;
                });
            });

            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql"
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}