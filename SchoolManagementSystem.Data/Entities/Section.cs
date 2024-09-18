namespace SchoolManagementSystem.Data.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }

}
