namespace SchoolManagementSystem.Data.Entities
{
    public class StudentEvaluation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }
        public double? ContinuousAssessment { get; set; }
        public double? FirstTest { get; set; }
        public double? SecondTest { get; set; }
        public double? Exam { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Semester Semester { get; set; }
        public Year Year { get; set; }

    }
}
