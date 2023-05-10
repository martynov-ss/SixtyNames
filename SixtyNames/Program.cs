
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            DBContext db = new DBContext();
            MainMenu menu = new MainMenu();

           menu.ShowMenu();
        }        
    }
}
