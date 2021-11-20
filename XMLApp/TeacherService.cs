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
        public TeacherService(IXMLManager<TeacherModel> teacherManager )
        {
            _teacherManager = teacherManager;
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
            int index=-1;
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
