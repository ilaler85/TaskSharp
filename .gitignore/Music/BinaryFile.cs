using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    class BinaryFile : IFileManager
    {
        public List<Schoolboy> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<Schoolboy>)bf.Deserialize(f);
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
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, list);
                    f.Close();
                }
                return true;
            }
            catch (Exception e)
            {
               
                return false;
            }
        }
    }
}
