using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApplication.Models;
using StudentManagementApplication.Service;

namespace StudentManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;
        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            int Count;
            List<Student> allStudents = _service.GetAllStudents(out Count);
            var reponse = new
            {
                students = allStudents,
                studentCount = Count
            };
            return Ok(reponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            if (_service.GetStudentById(id) == null)
            {
                return NotFound("Student Not Found");
            }
            else
            {
                return Ok(_service.GetStudentById(id));
            }
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (_service.AddStudent(student))
            {
                return Ok("Student Added Successfully");
            }
            else
            {
                return Conflict("Student with same Id or Email already exists");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updateStudent)
        {
            var updatedStudent = _service.UpdateStudent(id, updateStudent);
            if (updatedStudent != null)
            {
                return Ok(updatedStudent);
            }
            else
            {
                return NotFound("Student Not Found");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _service.GetStudentById(id);
            if (student != null)
            {
                Student.StudentsList.Remove(student);
                return Ok("Student Deleted Successfully");
            }
            else
            {
                return NotFound("Student Not Found");
            }
        }

        [HttpGet("course/{course}")]
        public IActionResult GetStudentsByCourse(string course)
        {
            List<Student> students = _service.GetStudentsByCourse(course);
            if (students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound("No Students found!");
            }
        }

        [HttpGet("age/{age}")]
        public IActionResult GetStudentsByAge(int age)
        {
            List<Student> students = _service.GetStudentsByAge(age);
            if (students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound("No Students found!");
            }
        }
    }
}
