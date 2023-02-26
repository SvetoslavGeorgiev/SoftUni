namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {

        public Course()
        {
            Homeworks = new HashSet<Homework>();
            Resources = new HashSet<Resource>();
            StudentsCourses = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }


        public ICollection<Homework> Homeworks { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }

    }
}
