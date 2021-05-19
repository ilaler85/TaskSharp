using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skolnik
{
    public interface IFileManager
    {
        bool SaveToFile(List<Schoolboy> list, string fileName);
        List<Schoolboy> LoadFromFile(string fileName);
    }
}