namespace SchoolManagementSystem.Data.Responses
{
    public class GetPartsOfStudentScheduleResponse
    {
        public int? Day { get; set; }
        public StudentSession? Session1 { get; set; }
        public StudentSession? Session2 { get; set; }
        public StudentSession? Session3 { get; set; }
        public StudentSession? Session4 { get; set; }
        public StudentSession? Session5 { get; set; }
        public StudentSession? Session6 { get; set; }
        public StudentSession? Session7 { get; set; }
    }
    public class StudentSession
    {
        public int SubjectTeacherId { get; set; }
        public string Info { get; set; }
    }
}
