namespace P01_StudentSystem.Data.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Student
    {

        public Student()
        {
            HomeworkSubmissions = new HashSet<Homework>();
            CourseEnrollments = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        
        public DateTime? Birthday  { get; set; }


        public ICollection<Homework> HomeworkSubmissions { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }


    }
}
