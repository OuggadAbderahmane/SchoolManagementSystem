using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Entities.Identity;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<YearOfLevel> YearOfLevels { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<PartOfSchedule> partsOfSchedules { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentEvaluation> StudentsEvaluations { get; set; }
        public DbSet<GetPartsOfScheduleView> GetPartsOfScheduleResponses { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<GetPartsOfScheduleView>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}