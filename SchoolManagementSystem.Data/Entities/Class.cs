namespace SchoolManagementSystem.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string? NameOfSpecialization { get; set; }
        public int LevelId { get; set; }
        public int YearOfLevelId { get; set; }

        public Level Level { get; set; }
        public YearOfLevel YearOfLevel { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }

}
