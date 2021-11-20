using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp
{
    [Serializable]
   public  class TeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<StudentModel> Students { get; set; }
        public TeacherModel()
        {

        }
        public TeacherModel(int id,string name,int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

    }
}
