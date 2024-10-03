namespace SchoolManagementSystem.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Guardian> guardians { get; set; } = new List<Guardian>();
    }
}
