using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            studentService.Add(new StudentModel(1, "Anna", 21));
            studentService.Add(new StudentModel(2, "Armen", 25));
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

        }
    }
}
