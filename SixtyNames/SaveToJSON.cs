using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    internal class SaveToJSON : IFileWriter
    {
        public void SaveToFile(string fileName, List<string> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(fileName, json);
        }
    }
}
