using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    class Program
    {
        static void Main(string[] args)
        {
            List_Assessment[] LA = new List_Assessment[11];
            List<Schoolboy> list;
            //LA = ConsoleMethods.InputSubject();
            do
            {
                list = ConsoleMethods.InputData(ref LA);
            }
            while (list == null);
            ConsoleMethods.PrintToConsole(list);
            int input;
            do
            {
                Console.WriteLine("Меню" +
                    "\n1 - Добавить школьников" +
                    "\n2 - Найти всех отличников" +
                    "\n3 - Сохранить в файл" +
                    "\n4 - Изменить данные о школьнике" +
                    "\n5 - Удалить данные о школьнике" +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        if (LA[0]  == null)
                        {
                            LA = ConsoleMethods.InputSubject();
                        }
                        list = list.Concat(ConsoleMethods.InputData(ref LA)).ToList();
                        ConsoleMethods.PrintToConsole(list);
                        break;
                    case 2:
                        Console.WriteLine("Отличники");
                        int[] Otl = new int[11];
                        for(int i = 0; i<list.Count; i++)
                        {
                            if (list[i].Search_excellent_student())
                            {
                                Otl[list[i].the_class-1] ++;
                                Console.WriteLine(list[i].ToString());
                            }
                        }
                        for (int i = 0; i<11;i++)
                        {
                            Console.WriteLine("Отличники в " + (i + 1).ToString()+" классе "+Otl[i].ToString());
                        }
                        break;
                    case 3:
                        string name;
                        IFileManager file = ConsoleMethods.ChooseFile(out name);
                        if (file.SaveToFile(list, name))
                        {
                            Console.WriteLine("Запись выполнена");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Выберите элемент для изменения, начиная с 0"); //method
                        int numEd;
                        if (LA[0] == null)
                        {
                            LA = ConsoleMethods.InputSubject();
                        }
                        int.TryParse(Console.ReadLine(), out numEd);
                        Schoolboy tmp = new Schoolboy();
                        tmp = ConsoleMethods.ReadSchoolboy(LA);
                        list[numEd] = tmp;
                        Console.WriteLine("Изменение завершено");
                        Console.ReadLine();
                        ConsoleMethods.PrintToConsole(list);
                        break;
                    case 5:
                        Console.WriteLine("Выберите элемент для удаления, начиная с 0 "+"до "+(list.Count-1).ToString()); //method
                        int numDel;
                        int.TryParse(Console.ReadLine(), out numDel);
                        list.RemoveAt(numDel);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        ConsoleMethods.PrintToConsole(list);
                        break;
                }
            }
            while (input != 0);
        }
    }
}
