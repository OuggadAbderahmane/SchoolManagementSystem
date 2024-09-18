namespace SchoolManagementSystem.Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    }

}
