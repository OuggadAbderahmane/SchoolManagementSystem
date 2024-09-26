namespace SchoolManagementSystem.Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }

        public Subject()
        {

        }
        public Subject(string name, int classId)
        {
            Name = name;
            ClassId = classId;
        }
        public Subject(int id, string name, int classId)
        {
            Id = id;
            Name = name;
            ClassId = classId;
        }

        public Class Class { get; set; }
        public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    }

}
