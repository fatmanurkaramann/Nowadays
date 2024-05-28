using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NowadaysDbContext>(options=>options.UseSqlServer(
                    configuration.GetConnectionString("NowadaysDb")
                ));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Repository Dependencies
            services.AddScoped<ICompanyDal, CompanyDal>();
            services.AddScoped<IEmployeeDal, EmployeeDal>();
            services.AddScoped<IIssueDal, IssueDal>();
            services.AddScoped<IProjectDal, ProjectDal>();
            #endregion 
        }
    }
}

