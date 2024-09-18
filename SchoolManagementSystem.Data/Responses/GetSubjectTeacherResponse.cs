namespace SchoolManagementSystem.Data.Responses
{
    public class GetSubjectTeacherResponse
    {
        public int Id { get; set; }
        public int TeacherID { get; set; }
        public string TeacherFullName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
