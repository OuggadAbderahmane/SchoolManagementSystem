namespace SchoolManagementSystem.Data.Entities
{
    public class Teacher : Person
    {
        public decimal Salary { get; set; }
        public bool PermanentWork { get; set; }
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
