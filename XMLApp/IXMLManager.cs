using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp
{
    public interface IXMLManager
    {
        void Insert(List<StudentModel> students);
        void Update(List<StudentModel> students);
        List<StudentModel> Read();
        void Delete(List<StudentModel> students);
    }
}
