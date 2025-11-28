using StudentManagementApplication.Models;

namespace StudentManagementApplication.Service
{
    public class StudentService
    {
        public List<Student> GetAllStudents(out int count)
        {
            count = Student.StudentsList.Count;
            return Student.StudentsList;
        }

        public Student GetStudentById(int id)
        {
            Student std = null;
            foreach (Student s in Student.StudentsList)
            {
                if (s.Id == id)
                {
                    std = s;
                    break;
                }
            }
            return std;
        }

        public Boolean AddStudent(Student student)
        {
            foreach(Student s in Student.StudentsList)
            {
                if(s.Id == student.Id || s.Email == student.Email)
                {
                    return false;
                }
            }
            Student.StudentsList.Add(student);
            return true;
        }
        public Student UpdateStudent(int id, Student student)
        {
            foreach(Student s in Student.StudentsList)
            {
                if(s.Id == id)
                {
                    s.Name = student.Name;
                    s.Age = student.Age;
                    s.Course = student.Course;
                    s.Email = student.Email;
                    return s;
                }
            }
            return null;
        }
        public List<Student> GetStudentsByCourse(string course)
        {
            List<Student> result = new List<Student>();
            foreach (Student s in Student.StudentsList)
            {
                if (s.Course == course)
                {
                    result.Add(s);
                }
            }
            return result;
        }
        public List<Student> GetStudentsByAge(int age)
        {
            List<Student> result = new List<Student>();
            foreach (Student s in Student.StudentsList)
            {
                if (s.Age == age)
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }
}
