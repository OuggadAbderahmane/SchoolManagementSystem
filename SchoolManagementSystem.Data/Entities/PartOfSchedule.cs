namespace SchoolManagementSystem.Data.Entities
{
    public class PartOfSchedule
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public sbyte Day { get; set; }
        public sbyte Session { get; set; }
        public int SubjectTeacherId { get; set; }

        public PartOfSchedule()
        {

        }
        public PartOfSchedule(int sectionId, sbyte day, sbyte session, int subjectTeacherId)
        {
            SectionId = sectionId;
            Day = day;
            Session = session;
            SubjectTeacherId = subjectTeacherId;
        }

        public SubjectTeacher SubjectTeacher { get; set; }
        public Section Section { get; set; }
    }
}
