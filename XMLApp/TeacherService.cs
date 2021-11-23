using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp
{
    public class TeacherService : ITeacherService
    {
        private readonly IXMLManager<TeacherModel> _teacherManager;
        private readonly IXMLManager<StudentModel> _studentManager;
        public TeacherService(IXMLManager<TeacherModel> teacherManager, IXMLManager<StudentModel> studentManager )
        {
            _teacherManager = teacherManager;
            _studentManager = studentManager;
        }
        public void Add(TeacherModel teacher)
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            try
            {
                teachers = _teacherManager.Read(); ;
            }
            catch (Exception ex)
            {

            }


            teachers.Add(teacher);

            _teacherManager.Insert(teachers);
        }

        public void Delete(int id)
        {
            List<TeacherModel> teachers = _teacherManager.Read();
            foreach (var teacher in teachers)
            {
                if (teacher.Id == id)
                {
                    teachers.Remove(teacher);
                    _teacherManager.Update(teachers);
                    break;
                }
            }
        }

        public TeacherModel Get(int id)
        {
            TeacherModel teacherModel = null;
            List<TeacherModel> teachers = _teacherManager.Read();
            foreach (var teacher in teachers)
            {
                if (teacher.Id == id)
                {
                    teacherModel = teacher;
                    return teacherModel;
                }
            }
            return teacherModel;

        }

        public List<TeacherModel> GetAll()
        {
            return _teacherManager.Read();
        }

        public void Update(TeacherModel teacher)
        {
            List<TeacherModel> teachers = _teacherManager.Read();
            List<StudentModel> students = _studentManager.Read();
            if (teacher.Students!=null)
            {
                int count = 0;
                int index = 0;
                for (int i = 0; i < students.Count; i++)
                {
                    if (teacher.Students[i].Id==students[i].Id)
                    {
                        for (int j = 0; j < teachers.Count; j++)
                        {
                            if (teachers[j].Id == teacher.Id)
                            {
                                index = j;
                                break;
                            }
                        }
                        count++;
                    }
                    if (count!=0)
                    {
                        teachers[index] = teacher;
                        _teacherManager.Update(teachers);
                    }
                    else
                    {
                        throw new Exception(" Student is not on the list");
                    }
                }
            }
            else
            {
                int index = 0;
                for (int i = 0; i < teachers.Count; i++)
                {
                    if (teachers[i].Id == teacher.Id)
                    {
                        index = i;
                        break;
                    }
                }

                teachers[index] = teacher;
                _teacherManager.Update(teachers);
            }
        }
    }
}
