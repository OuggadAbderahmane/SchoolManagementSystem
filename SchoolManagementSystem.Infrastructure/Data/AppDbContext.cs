using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

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
        public DbSet<FinalExam> FinalExams { get; set; }
        public DbSet<GetPartsOfScheduleView> GetPartsOfScheduleResponses { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public string GetClassInfo(int Id)
        {
            var result = Database.SqlQueryRaw<string>("select dbo.GetClassInfo(@p0)", Id).AsEnumerable().FirstOrDefault();
            return result!;
        }
    }
}


/*
 
 
        public Task<bool> AddNewTeacherByPerson(int PersonId, decimal Salary, bool PermanentWork = false)
        {
            var newTeacherId = new SqlParameter
            {
                ParameterName = "@NewTeacherId",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var idParameter = new SqlParameter("@Id", PersonId);

            try
            {
                _dbContext.Database.ExecuteSqlRaw(
                "EXEC AddNewTeacher @Id, @Salary, @PermanentWork, @NewTeacherId OUTPUT",
                new SqlParameter("@Salary", Salary),
                new SqlParameter("@PermanentWork", PermanentWork),
                newTeacherId);
            }
            catch
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
 
 */