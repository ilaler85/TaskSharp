using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Skolnik
{
    class XmlFile : IFileManager
    {
        public List<Schoolboy> LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<Schoolboy>));
                    return (List<Schoolboy>)s.Deserialize(reader);
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
                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    XmlSerializer s = new XmlSerializer(typeof(List<Schoolboy>));
                    s.Serialize(writer, list);
                    writer.Close();
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
