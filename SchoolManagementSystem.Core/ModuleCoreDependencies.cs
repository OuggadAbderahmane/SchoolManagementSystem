using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Core.Behaviors;
using System.Reflection;

namespace SchoolManagementSystem.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // configuration of Mediater 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // configuration of AutoMapper
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
