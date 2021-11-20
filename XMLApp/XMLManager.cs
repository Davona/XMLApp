using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLApp
{
    public class XMLManager : IXMLManager
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StudentModel>));
        public void Insert(List<StudentModel> student)
        {
            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, student);
            }
        }

        public List<StudentModel> Read()
        {
            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                List<StudentModel> students = (List<StudentModel>)xmlSerializer.Deserialize(fs);

                return students;
            }
        }
      

        public void Update(List<StudentModel> students)
        {
            using (StreamWriter wr = new StreamWriter("students.xml"))
            {

                xmlSerializer.Serialize(wr, students);
            }
        }
        public void Delete( List<StudentModel> students)
        {
            using (StreamWriter wr = new StreamWriter("students.xml"))
            {
               
                xmlSerializer.Serialize(wr, students);
            }
        }


    }
}
