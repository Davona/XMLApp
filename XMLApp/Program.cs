using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService(new XMLManager<StudentModel>("students.xml"),new XMLManager<TeacherModel>("teachers.xml"));
            StudentModel st = new StudentModel(1, "Anna", 21);
            st.Teacher = new TeacherModel(21, "sfas", 13);
            studentService.Add(st);
            studentService.Add(new StudentModel(3, "Ashot", 23));
            studentService.Add(new StudentModel(4, "Misak", 29));
            studentService.Add(new StudentModel(5, "Movses", 19));
            studentService.Add(new StudentModel(6, "Vaspur", 27));
            List<StudentModel> vs= studentService.GetAll();
            StudentModel student = studentService.Get(3);
            studentService.Delete(5);
            studentService.Delete(4);
            List<StudentModel> studentModels = studentService.GetAll();
            studentService.Update(new StudentModel(6, "Gayane", 26));
            List<StudentModel> students = studentService.GetAll();
            TeacherService teacherService = new TeacherService(new XMLManager<TeacherModel>("teachers.xml"));
            teacherService.Add(new TeacherModel(1, "Anna", 25));
            teacherService.Add(new TeacherModel(2, "Ani", 45));
            teacherService.Add(new TeacherModel(3, "Aram", 32));

        }
    }
}
