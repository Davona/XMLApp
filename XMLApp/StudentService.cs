using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp
{
    public class StudentService : IStudentService
    {
        List<StudentModel> students;
        XMLManager manager;
       
        public StudentService()
        {
            students = new List<StudentModel>();
            manager = new XMLManager();
        }
        public void Add(StudentModel student)
        {
            List<StudentModel> _students = students;
            students.Add(student);
           
            manager.Insert(_students);
           
        }

        public void Delete(int id)
        {
            List<StudentModel> _students = students;
            foreach (var student in _students)
            {
                if (student.Id==id)
                {
                    _students.Remove(student);
                    manager.Delete(_students);
                    break;
                }
            }
        }

        public StudentModel Get(int id)
        {
            StudentModel studentModel=null;
            List<StudentModel> students = manager.Read();
            foreach (var student in students)
            {
                if (student.Id==id)
                {
                    studentModel = student;
                    return studentModel;
                }
            }
            return studentModel;
        }

        public List<StudentModel> GetAll()
        {
            return manager.Read();
        }

        public void Update(StudentModel student)
        {
            StudentModel wrongStudent = null;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == student.Id)
                {
                    wrongStudent = students[i];
                    break;
                }
            }
            int wrongStudentidx = students.IndexOf(wrongStudent);
            students[wrongStudentidx] = student;
            manager.Update(students);
        }
    }
}

