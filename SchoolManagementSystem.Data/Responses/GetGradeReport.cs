namespace SchoolManagementSystem.Data.Responses
{
    public class GetGradeReport
    {
        public string Semester { get; set; }
        public ICollection<Evaluation> Evaluation { get; set; }
    }
    public class Evaluation
    {
        public int StudentEvaluationId { get; set; }
        public string SubjectName { get; set; }
        public double? ContinuousAssessment { get; set; }
        public double? FirstTest { get; set; }
        public double? SecondTest { get; set; }
        public double? Exam { get; set; }
    }
}
