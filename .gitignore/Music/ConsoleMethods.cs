using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    public class ConsoleMethods
    {
        public static void PrintToConsole(List<Schoolboy> list)
        {
            int count = 0;
            foreach (var item in list)
            {
                Console.Write(String.Format("{0} - ", count));
                Console.WriteLine(item.ToString());
                count++;
            }
            Console.WriteLine(String.Format("Количество учеников: {0}", count));
            Console.ReadLine();
            Console.WriteLine();
        }

        public static List<Schoolboy> InputData(ref List_Assessment[] LA)
        {
            Console.WriteLine("1 - ввод с консоли, 2 - загрузить из файла");
            int inputType;
            int.TryParse(Console.ReadLine(), out inputType);
            switch (inputType)
            {
                case 1:
                    if(LA[0] == null)
                    {
                        LA = InputSubject();
                    }
                    return InputDataFromConsole(LA);
                case 2:
                    string name;
                    return ChooseFile(out name).LoadFromFile(name);
                default:
                    Console.WriteLine("Ошибка, повторите ввод");
                    return null;
            }
        }

        public static List<Schoolboy> InputDataFromConsole(List_Assessment[] LA)
        {
            char exitChar;
            List<Schoolboy> list = new List<Schoolboy>();
            do
            {
                Console.WriteLine("Введите информацию о школьнике");
                SetComposition(list, LA);
                Console.WriteLine("Если хотите добавить еще одного школьника - нажмите любую кнопку, для отмены ввода нажмите 0");
                char.TryParse(Console.ReadLine(), out exitChar);
            }
            while (exitChar != '0');
            return list;
        }
        public static List_Assessment[] InputSubject()
        {
            List_Assessment[] LA = new List_Assessment[11];
            for (int i=0; i<11;i++)
            {
                List_Assessment LAtmp = new List_Assessment();
                bool OK = true;
                Console.WriteLine("Введите названия предметов для "+(i+1).ToString());
                while (OK)
                {
                    Console.WriteLine("Введите название предмета");
                    string Sub = Console.ReadLine();
                    Assessment Tmp = new Assessment(Sub, 0);
                    LAtmp.LAssessment.Add(Tmp);
                    Console.WriteLine("хотите ввести еще, нажмите любую кнопку. Для выхода нажмите 0");
                    char exit;
                    char.TryParse(Console.ReadLine(), out exit);
                    if (exit == '0')
                    {
                        OK = false;
                    }
                }
                LA[i] = LAtmp;
            }
            return LA;
        }

        public static int Chek(int left, int right)
        {
            int tmp;
            do{
                int.TryParse(Console.ReadLine(), out tmp);
                if (tmp<left || tmp>right)
                {
                    Console.WriteLine("Ошибка ввода");
                }
            }while (tmp < left || tmp > right) ;
            return tmp;
        }
        public static Schoolboy ReadSchoolboy(List_Assessment[] LA)
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите отчество");
            string patronomic = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите год обучения");
            int year_of_study = Chek(1980, 2020);
            Console.WriteLine("Введите класс");
            int the_class = Chek(1,11);
            Console.ReadLine();

            Console.WriteLine("Введите оценки по предметам");
            Assessment[] As = LA[the_class - 1].LAssessment.ToArray();
            for (int i = 0; i < As.Length; i++)
            {
                Console.WriteLine("Введите оценку по " + As[i].subject);
                As[i].assessment = Chek(1,5);
            }
            Schoolboy Boy = new Schoolboy(name, patronomic, surname, year_of_study, the_class, As);
            return Boy;
        }
        public static void SetComposition(List<Schoolboy> list, List_Assessment[] LA)
        {
            /* Console.WriteLine("Введите имя");
             string name = Console.ReadLine();
             Console.WriteLine("Введите отчество");
             string patronomic = Console.ReadLine();
             Console.WriteLine("Введите фамилию");
             string surname = Console.ReadLine();
             Console.WriteLine("Введите год обучения");
             int year_of_study;
             int.TryParse(Console.ReadLine(), out year_of_study);
             Console.WriteLine("Введите класс");
             int the_class;
             int.TryParse(Console.ReadLine(), out the_class);
             Console.ReadLine();

             Console.WriteLine("Введите оценки по предметам");
             Assessment[] As = LA[the_class - 1].LAssessment.ToArray();
             for(int i = 0; i<As.Length; i++)
             {
                 Console.WriteLine("Введите оценку по "+As[i].subject);
                 int.TryParse(Console.ReadLine(), out int tm);
                 As[i].assessment = tm;
             }*/
            Schoolboy tmp = new Schoolboy();
            tmp = ReadSchoolboy(LA);
            list.Add(tmp);
        }

        public static IFileManager ChooseFile(out string fName)
        {
            Console.WriteLine("Введите имя файла: ");
            string input = Console.ReadLine();
            fName = input;
            return FileExtension.GetFile(Path.GetExtension(input));
        }
    }
}
