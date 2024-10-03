namespace SchoolManagementSystem.Data.Responses
{
    public class GetPartsOfTeacherScheduleResponse
    {
        public int? Day { get; set; }
        public TeacherSession? Session1 { get; set; }
        public TeacherSession? Session2 { get; set; }
        public TeacherSession? Session3 { get; set; }
        public TeacherSession? Session4 { get; set; }
        public TeacherSession? Session5 { get; set; }
        public TeacherSession? Session6 { get; set; }
        public TeacherSession? Session7 { get; set; }
    }

    public class TeacherSession
    {
        public int SectionId { get; set; }
        public string Info { get; set; }
    }
}
