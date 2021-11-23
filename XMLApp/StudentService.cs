using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp
{
    public class StudentService : IStudentService
    {

        private readonly IXMLManager<StudentModel> _studentManager;
        private readonly IXMLManager<TeacherModel> _teacherManager;


        public StudentService(IXMLManager<StudentModel> studentManager, IXMLManager<TeacherModel> teacherManager)
        {

            _studentManager = studentManager;
            _teacherManager = teacherManager;


        }
        public void Add(StudentModel student)
        {
            List<StudentModel> students = new List<StudentModel>();

            try
            {
                students = _studentManager.Read(); ;
            }
            catch (Exception ex)
            {

            }


            List<TeacherModel> teachers = _teacherManager.Read();
            int count = 0;
            for (int i = 0; i < teachers.Count; i++)
            {
                if (student.Teacher.Id == teachers[i].Id)
                {
                    count++;
                   
                }
            }
            if (count!=0)
            {
                students.Add(student);
                _studentManager.Insert(students);
            }
            else
            {
                throw new Exception("The teacher is not on the list");
            }
           

        }

        public void Delete(int id)
        {
            List<StudentModel> students = _studentManager.Read();
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    students.Remove(student);
                    _studentManager.Update(students);
                    break;
                }
            }
        }

        public StudentModel Get(int id)
        {
            List<StudentModel> students = _studentManager.Read();
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public List<StudentModel> GetAll()
        {
            return _studentManager.Read();
        }
        public void Update(StudentModel student)
        {
            List<StudentModel> students = _studentManager.Read();
            List<TeacherModel> teachers = _teacherManager.Read();
            int index = 0;
            int count = 0;
            for (int i = 0; i < teachers.Count; i++)
            {
                if (student.Teacher.Id==teachers[i].Id)
                {
                    for (int j = 0; j < students.Count; j++)
                    {
                        if (students[j].Id == student.Id)
                        {
                            index = j;
                            break;
                        }
                    }
                    count++;
                }
            }
            if (count!=0)
            {
                students[index] = student;
                _studentManager.Update(students);
            }
            else
            {
                throw new Exception("The teacher is not on the list");
            }
        }
    }
}

