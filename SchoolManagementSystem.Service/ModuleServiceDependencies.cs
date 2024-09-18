using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Service.Abstracts;
using SchoolManagementSystem.Service.Implementations;

namespace SchoolManagementSystem.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PesronService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<ILevelService, LevelService>();
            services.AddTransient<IYearOfLevelService, YearOfLevelService>();
            services.AddTransient<IYearService, YearService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IGuardianService, GuardianService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IPartOfScheduleService, PartOfScheduleService>();
            services.AddTransient<ISubjectTeacherService, SubjectTeacherService>();
            services.AddTransient<IFinalExamService, FinalExamService>();
            services.AddTransient<ISemesterService, SemesterService>();

            return services;
        }

    }
}
