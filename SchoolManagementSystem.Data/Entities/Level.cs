﻿namespace SchoolManagementSystem.Data.Entities
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Class> Class { get; set; } = new List<Class>();
    }

}
