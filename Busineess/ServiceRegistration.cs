using Busineess.Abstract;
using Busineess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Busineess.Rules;

namespace Busineess
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            #region Service Dependencies
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IPersonValidationService, PersonValidationService>();
            #endregion

            #region BusinessRules Dependencies
            services.AddScoped<ProjectBusinessRules>();
            services.AddScoped<IssueBusinessRules>();
            #endregion
        }
    }
}

