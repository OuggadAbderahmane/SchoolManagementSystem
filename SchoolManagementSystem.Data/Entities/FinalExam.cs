namespace SchoolManagementSystem.Data.Entities
{
    public class FinalExam
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
        public int YearId { get; set; }
        public double FinalExamNote { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Semester Semester { get; set; }
        public Year Year { get; set; }

    }
}
