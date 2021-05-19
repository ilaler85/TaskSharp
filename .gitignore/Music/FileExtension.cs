using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik   
{
    static public class FileExtension
    {
        public static IFileManager GetFile(string extension)
        {
            IFileManager file;
            switch (extension)
            {
                case ".txt":
                    file = new TxtFile();
                    break;
                case ".bin":
                    file = new BinaryFile();
                    break;
                case ".xml":
                    file = new XmlFile();
                    break;
                default: throw new Exception("Неверно указано расширение файла");
            }
            return file;
        }
    }
}
