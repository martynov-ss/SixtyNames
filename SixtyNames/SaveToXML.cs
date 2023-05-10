using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class SaveToXML : IFileWriter
    {
        public void SaveToFile(string fileName, List<string> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, list);
            fStream.Close();
        }
    }
}
