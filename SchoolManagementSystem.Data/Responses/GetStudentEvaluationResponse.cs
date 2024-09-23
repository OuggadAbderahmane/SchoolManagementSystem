namespace SchoolManagementSystem.Data.Responses
{
    public class GetStudentEvaluationResponse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentFulName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public double? ContinuousAssessment { get; set; }
        public double? FirstTest { get; set; }
        public double? SecondTest { get; set; }
        public double? Exam { get; set; }
    }
}
