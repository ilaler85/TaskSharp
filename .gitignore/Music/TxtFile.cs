using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    class TxtFile : IFileManager
    {
        public List<Schoolboy> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    List<Schoolboy> list = new List<Schoolboy>();
                    while (sr.Peek() > -1)
                    {
                        string name = sr.ReadLine();
                        string Patronymic = sr.ReadLine();
                        string Surname = sr.ReadLine();
                        int the_class=
                        int.Parse(sr.ReadLine());
                        int yaer=
                        int.Parse(sr.ReadLine());
                        int len=
                        int.Parse(sr.ReadLine());
                        Assessment[] As = new Assessment[len];
                        for (int i =0; i<len; i++)
                        {
                            string sub = sr?.ReadLine();
                            int tmpp;
                            int.TryParse(sr?.ReadLine(), out tmpp);
                            Assessment Astmp = new Assessment(sub, tmpp);
                            As[i] = Astmp;
                        }
                        sr?.ReadLine();
                        Schoolboy tmp = new Schoolboy(name, Patronymic, Surname,yaer,the_class,As);
                        list.Add(tmp);
                    }
                    sr.Close();
                    return list;
                }
            }
            else
            {
                throw new Exception("Такого файла не существует");
            }

        }

        public bool SaveToFile(List<Schoolboy> list, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.Name);
                        sw.WriteLine(item.Patronymic);
                        sw.WriteLine(item.Surname);
                        sw.WriteLine(item.the_class.ToString());
                        sw.WriteLine(item.year_of_study.ToString());
                        sw.WriteLine(item.Progress.Length);
                        for(int i = 0; i<item.Progress.Length; i++)
                        {
                            sw.WriteLine(item.Progress[i].subject);
                            sw.WriteLine(item.Progress[i].assessment);
                        }
                        sw.WriteLine();
                    }
                    sw.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
