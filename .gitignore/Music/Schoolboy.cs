using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    [Serializable]
    public class Schoolboy
    {
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public int year_of_study { get; set; }
        public int the_class { get; set; }
        //public string subject { get; set; }
        public Assessment[] Progress { get; set; }

        public Schoolboy(string Name, string Patronymic, string Surname, int year_of_study, int the_class, Assessment[] L)
        {
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.Surname = Surname;
            this.year_of_study = year_of_study;
            this.the_class = the_class;
            this.Progress = L;

        }
        
        public Schoolboy() { }
        
        public override string ToString()
        {
            return string.Format("ФИО: {0} {1} {2}, класс: {3}, год обучения {4} \n{5}\n",
                           Surname, Name, Patronymic, the_class.ToString(), year_of_study.ToString(), ProgStr());
        }
        public string ProgStr()
        {
            string str="";
            for(int i = 0; i<Progress.Length; i++)
            {
                str += Progress[i].ToString();
            }
            return str;
        }
        public bool Search_excellent_student()
        {
            bool Ok = true;
            int i = 0;
            while (Ok && (i<Progress.Length))
            {
                if (Progress[i].assessment == 5)
                {
                    Ok = true;
                }
                else
                {
                    Ok = false;
                }
                i++;
            }
            return Ok;
        }
    }
}
