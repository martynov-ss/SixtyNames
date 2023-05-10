using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MainMenu
    {        
        public bool Menu()
        { 
            Console.Clear();
            Console.WriteLine("Список возможных действий:");
            Console.WriteLine("1) Вывести сумму всех заключенных договоров за текущий год");
            Console.WriteLine("2) Вывести сумму заключенных договоров по каждому контрагенту из России");
            Console.WriteLine("3) Вывести список e-mail уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000");
            Console.WriteLine("4) Изменить статус договора на \"Расторгнут\" для физических лиц, возраст которых старше 60 лет включительно");
            Console.WriteLine("5) Создать отчет (xml, json) по компаниям, расположенных в городе Москва");
            Console.WriteLine("6) Выход из программы");
            Console.Write("\r\nВыберерите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    GetSumContracts();                    
                    return true;
                case "2":
                    GetSumContractsRu();                   
                    return true;
                case "3":
                    GetEmails();
                    return true;
                case "4":
                    StatusChange();
                    return true;
                case "5":
                    SaveToFile();
                    return true;
                case "6":
                    return false;
                default:
                    return true;
            }            
        }
 
        public void ShowMenu()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }
        private static void GetSumContracts()
        {
            DataDbParser GetData = new DataDbParser();
            Console.WriteLine(GetData.GetSumContracts());
            ReturnMenu();
        }
        private static void GetSumContractsRu()
        {
            DataDbParser GetData = new DataDbParser();
            Console.WriteLine(String.Join(", ", GetData.GetSumContractsRu()));
            ReturnMenu();
        }
        private static void GetEmails()
        {
            DataDbParser GetData = new DataDbParser();
            Console.WriteLine(String.Join(", ", GetData.GetEmails()));
            ReturnMenu();
        }
        private static void StatusChange()
        {
            DataDbParser GetData = new DataDbParser();
            Console.WriteLine($"Расторгнуто {GetData.StatusChange()} договора(ов)\n");
            ReturnMenu();
        }
        private static void SaveToFile()
        {
            SaveToJSON jsonWriter = new SaveToJSON();
            SaveToXML xmlWriter = new SaveToXML();
            DataDbParser GetData = new DataDbParser();
            jsonWriter.SaveToFile("export.json", GetData.ExportData());
            xmlWriter.SaveToFile("export.xml", GetData.ExportData());
            ReturnMenu();
        }
        private static void ReturnMenu()
        {
            Console.Write("\r\nНажмите \"Enter\" для возврата в главное меню");
            Console.ReadLine();
        }
    }
}
