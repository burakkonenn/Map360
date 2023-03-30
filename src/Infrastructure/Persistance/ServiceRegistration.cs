
using Application.Abstractions.Repositories;
using Application.Abstractions.Repositories.Company;
using Application.Abstractions.Repositories.User;
using Application.Abstractions.Services.Company;
using Application.Abstractions.Services.CompanyTasks;
using Application.Abstractions.Services.User;
using Application.DTOs.Company;
using Application.Validators.Company;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.Repositories.User;
using Persistance.Services;
using Persistance.Services.Company;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();

            services.AddScoped<ITaskReadRepository, TaskReadRepository>();
            services.AddScoped<ITaskWriteRepository, TaskWriteRepository>();



            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();


            //Fluent validation
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CompanyCreateDto>, CompanyCreateValidator>();
            services.AddScoped<IValidator<CompanyUpdateDto>, CompanyUpdateValidator>();


            return services;

        }
    }
}
