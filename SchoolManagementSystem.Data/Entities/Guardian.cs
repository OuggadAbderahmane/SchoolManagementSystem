namespace SchoolManagementSystem.Data.Entities
{
    public class Guardian : Person
    {
        public int JobID;

        public Job Job;
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
