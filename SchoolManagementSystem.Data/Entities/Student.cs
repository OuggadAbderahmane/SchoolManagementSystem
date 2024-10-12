﻿namespace SchoolManagementSystem.Data.Entities
{
    public class Student : Person
    {
        public int? SectionId { get; set; }
        public int? GuardianId { get; set; }
        public bool IsActive { get; set; }

        public Section? Section { get; set; }
        public Guardian? guardian { get; set; }
        public ICollection<StudentEvaluation> StudentEvaluations { get; set; } = new List<StudentEvaluation>();
    }
}
