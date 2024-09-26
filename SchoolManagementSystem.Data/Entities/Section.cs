namespace SchoolManagementSystem.Data.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }

        public Section() { }
        public Section(string name, int classId)
        {
            Name = name;
            ClassId = classId;
        }
        public Section(int id, string name, int classId)
        {
            Id = id;
            Name = name;
            ClassId = classId;
        }

        public Class Class { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }

}
