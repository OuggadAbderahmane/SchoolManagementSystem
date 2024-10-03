namespace SchoolManagementSystem.Data.Entities
{
    public class SubjectTeacher
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public SubjectTeacher() { }
        public SubjectTeacher(int subjectId, int teacherId)
        {
            SubjectId = subjectId;
            TeacherId = teacherId;
        }

        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<PartOfSchedule> PartOfSchedules { get; set; } = new List<PartOfSchedule>();
    }
}
