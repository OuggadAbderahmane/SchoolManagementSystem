using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Bases;
using SchoolManagementSystem.Infrastructure.HelperClass;
using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHelperClass, helperClass>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<ILevelRepository, LevelRepository>();
            services.AddTransient<IYearOfLevelRepository, YearOfLevelRepository>();
            services.AddTransient<IYearRepository, YearRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IGuardianRepository, GuardianRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IPartOfScheduleRepository, PartOfScheduleRepository>();
            services.AddTransient<ISubjectTeacherRepository, SubjectTeacherRepository>();
            services.AddTransient<IStudentEvaluationRepository, StudentEvaluationRepository>();
            services.AddTransient<ISemesterRepository, SemesterRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();

            return services;
        }

    }
}
