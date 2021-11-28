using System.Reflection;
using CarRental.Application.Common;
using CarRental.Application.Common.Behaviours;
using CarRental.Application.Features.Rentals.Commands.CreateRental;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IValidationErrorHandler<CreateRentalCommand>, CreateRentalHandler>();

            return services;
        }
    }
}