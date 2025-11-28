using System.ComponentModel.DataAnnotations;

namespace StudentManagementApplication.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public int? Age {  get; set; }
        public string Course { get; set; } = string.Empty;
        [Required]
        public string Email {  get; set; } = string.Empty;

        public static List<Student> StudentsList = new List<Student>()
        {
            new Student() { Id = 1, Name = "Amit Chavan", Age = 20, Course = ".Net Basics", Email = "amit@gmail.com" },
            new Student() { Id = 2, Name = "Bob Smith", Age = 22, Course = ".Net", Email = "bob@gmail.com" },
            new Student() { Id = 3, Name = "Charlie Brown", Age = 21, Course = "Angular", Email = "charlie@gmail.com" },
            new Student() { Id = 4, Name = "Diana Prince", Age = 23, Course = ".Net", Email = "diana@gmail.com" },
            new Student() { Id = 5, Name = "Ethan Hunt", Age = 24, Course = ".Net Basics", Email = "ethan@gmail.com" }
        };
    }
}

