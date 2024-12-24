﻿namespace School.API.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public string Grade {  get; set; } = string.Empty;
    }

}
