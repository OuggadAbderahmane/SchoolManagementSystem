namespace SchoolManagementSystem.Data.Responses
{
    public class GetPartsOfScheduleResponse
    {
        public int? Day { get; set; }
        public Session? Session1 { get; set; }
        public Session? Session2 { get; set; }
        public Session? Session3 { get; set; }
        public Session? Session4 { get; set; }
        public Session? Session5 { get; set; }
        public Session? Session6 { get; set; }
        public Session? Session7 { get; set; }
    }
    public class Session
    {
        public int SubjectTeacherId { get; set; }
        public string Info { get; set; }
    }
}
