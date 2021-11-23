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
            TeacherService teacherService = new TeacherService(new XMLManager<TeacherModel>("teachers.xml"), new XMLManager<StudentModel>("students.xml"));
            StudentService studentService = new StudentService(new XMLManager<StudentModel>("students.xml"), new XMLManager<TeacherModel>("teachers.xml"));
            TeacherModel teacher1 = new TeacherModel(1, "Anna", 35);
            TeacherModel teacher2 = new TeacherModel(2, "Ashot", 50);
            TeacherModel teacher3 = new TeacherModel(3, "Ani", 41);
            teacherService.Add(teacher1);
            teacherService.Add(teacher2);
            teacherService.Add(teacher3);
            StudentModel student1 = new StudentModel(1, "Aram", 19);
            StudentModel student2 = new StudentModel(2, "Armen", 25);
            StudentModel student3 = new StudentModel(3, "Davit", 17);
            StudentModel student4 = new StudentModel(4, "Saten", 16);
            StudentModel student5 = new StudentModel(5, "Sona", 24);
            student1.Teacher = teacher1;
            studentService.Add(student1);
            student2.Teacher = teacher3;
            studentService.Add(student2);
            student3.Teacher = teacher1;
            studentService.Add(student3);
            student4.Teacher = teacher2;
            studentService.Add(student4);
            student5.Teacher = teacher3;
            studentService.Add(student5);
            List<StudentModel> students = studentService.GetAll();
            teacher1.Students = students;
            teacherService.Update(teacher1);

           
           
           
            

        }
    }
}
