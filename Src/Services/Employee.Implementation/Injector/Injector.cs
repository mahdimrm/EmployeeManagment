using Employee.Abstraction;
using Employee.DataBase;
using FishForoshi.Abstraction;
using Infrastructure.Implementation.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Implementation.Injector
{
    public static class Injector
    {
        public static void AddEmployeeServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("EmployeeDb") ?? "";
            EmployeeDbContext.ConnectionString = connectionString;

            services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectionString));

            services.AddBaseServices();
            services.AddActionServices();
        }

        static void AddBaseServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IQuery<>), typeof(Query<>));
            services.AddScoped(typeof(ICud<>), typeof(Cud<>));
        }

        static void AddActionServices(this IServiceCollection services)
        {

            #region Employee
            services.AddTransient<IGetEmployee, GetEmployee>();
            services.AddTransient<IEmployeeAction, EmployeeAction>();
            #endregion

            #region Grade

            services.AddTransient<IGetGrade, GetGrade>();
            services.AddTransient<IGradeAction, GradeAction>();

            #endregion

            #region Wife
            services.AddTransient<IGetWife, GetWife>();
            services.AddTransient<IWifeAction, WifeAction>();
            #endregion

            #region Child
            services.AddTransient<IGetChild, GetChild>();
            services.AddTransient<IChildAction, ChildAction>();
            #endregion

        }
    }
}
