namespace SchoolManagementSystem.Data.Entities
{
    public class Teacher : Person
    {
        public bool PermanentWork { get; set; }
        public ICollection<Subject> Subjects { get; set; } = [];
    }

}
