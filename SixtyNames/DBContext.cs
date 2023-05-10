using System.Globalization;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

namespace ConsoleApp1
{
   
    public class DBContext : DbContext
    {
        private string strCon = ConfigurationManager.ConnectionStrings["MSSQLLocalConnectionString"].ConnectionString;
        public DBContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(strCon);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhysicalPersons>().HasData(
                new PhysicalPersons { PhysicalPersonsId = 1, Name = "Иван", Surname = "Иванов", Patronymic = "Иванович", Gender = "муж", Age = 37, Job = "ООО \"Фирма1\"", Country = "Россия",
                    City = "Самара", Address = "адрес1", Email = "ivanov@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("15.01.1986", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 2, Name = "Петр", Surname = "Петрович", Patronymic = "Петров", Gender = "муж", Age = 43, Job = "ООО \"Фирма2\"", Country = "Россия",
                    City = "Нижний Новгород", Address = "адрес2", Email = "email2@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("10.04.1980", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 3, Name = "Сергей", Surname = "Сергеевич", Patronymic = "Сергеев", Gender = "муж", Age = 65, Job = "ООО \"Фирма3\"", Country = "Россия",
                    City = "Саров", Address = "адрес3", Email = "email3@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("20.05.1958", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId =4, Name = "Имя4", Surname = "Фамилия4", Patronymic = "Отчество4", Gender = "муж", Age = 55, Job = "ЗАО \"Фирма4\"", Country = "Белоруссия",
                    City = "Минск", Address = "адрес4", Email = "email4@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("30.12.1969", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 5, Name = "Имя5", Surname = "Фамилия5", Patronymic = "Отчество5", Gender = "муж", Age = 61, Job = "ООО \"Фирма5\"", Country = "Казахстан",
                    City = "Астана", Address = "адрес5", Email = "email5@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("25.03.1962", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 6, Name = "Имя6", Surname = "Фамилия6", Patronymic = "Отчество6", Gender = "муж", Age = 45, Job = "ПАО \"Фирма6\"", Country = "Россия",
                    City = "Москва", Address = "адрес6", Email = "email6@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("07.07.1977", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 7, Name = "Имя7", Surname = "Фамилия7", Patronymic = "Отчество7", Gender = "муж", Age = 46, Job = "ПАО \"Фирма7\"", Country = "Россия",
                    City = "Москва", Address = "адрес7", Email = "email7@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("07.07.1976", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 8, Name = "Имя8", Surname = "Фамилия8", Patronymic = "Отчество8", Gender = "муж", Age = 47, Job = "ПАО \"Фирма8\"", Country = "Россия",
                    City = "Москва", Address = "адрес8", Email = "email8@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("07.07.1975", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 9, Name = "Имя9", Surname = "Фамилия9", Patronymic = "Отчество9", Gender = "муж", Age = 48, Job = "ПАО \"Фирма9\"", Country = "Россия",
                    City = "Москва", Address = "адрес9", Email = "email9@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("07.07.1974", "dd.MM.yyyy", CultureInfo.CurrentCulture) },
                new PhysicalPersons { PhysicalPersonsId = 10, Name = "Имя10", Surname = "Фамилия10", Patronymic = "Отчество10", Gender = "муж", Age = 61, Job = "ПАО \"Фирма10\"", Country = "Россия",
                    City = "Москва", Address = "адрес10", Email = "email10@domain.ru", Phone = "+71234567890", Birthday = DateTime.ParseExact("07.07.1961", "dd.MM.yyyy", CultureInfo.CurrentCulture) }
                );
            modelBuilder.Entity<LegalPersons>().HasData(
                new LegalPersons { LegalPersonsId = 1,  CompanyName = "OOO \"Фирма1\"", Inn = 11111, Ogrn = 11111, Country = "Россия",
                    City = "Самара", Address = "адрес1", Phone = "+71234567890", Email = "email1@domain.ru" },
                new LegalPersons { LegalPersonsId = 2, CompanyName = "OOO \"Фирма2\"", Inn = 22222, Ogrn = 22222, Country = "Россия",
                    City = "Нижний Новгород", Address = "адрес2", Phone = "+71234567890", Email = "email2@domain.ru" },
                new LegalPersons { LegalPersonsId = 3, CompanyName = "OOO \"Фирма3\"", Inn = 33333, Ogrn = 33333, Country = "Казахстан",
                    City = "Астана", Address = "адрес3", Phone = "+71234567890", Email = "email3@domain.ru" },
                new LegalPersons { LegalPersonsId = 4, CompanyName = "OOO \"Фирма4\"", Inn = 44444, Ogrn = 44444, Country = "Белоруссия",
                    City = "Минск", Address = "адрес4", Phone = "+71234567890", Email = "email4@domain.ru" },
                new LegalPersons { LegalPersonsId = 5, CompanyName = "OOO \"Фирма5\"", Inn = 55555, Ogrn = 55555, Country = "Россия",
                    City = "Москва", Address = "адрес5", Phone = "+71234567890", Email = "email5@domain.ru" }
            );
            modelBuilder.Entity<Contracts>().HasData(
                new Contracts {ContractsId = 1, PhysicalPersonsId = 1, LegalPersonsId = 1, DateOfSign = DateTime.ParseExact("11.01.2020", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 100000, Status = "Подписан" },
                new Contracts { ContractsId = 2, PhysicalPersonsId = 2, LegalPersonsId = 1, DateOfSign = DateTime.ParseExact("12.02.2020", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 200000, Status = "Подписан" },
                new Contracts { ContractsId = 3, PhysicalPersonsId = 3, LegalPersonsId = 2, DateOfSign = DateTime.ParseExact("13.04.2020", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 250000, Status = "Подписан" },
                new Contracts { ContractsId = 4, PhysicalPersonsId = 4, LegalPersonsId = 2, DateOfSign = DateTime.ParseExact("14.06.2020", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 80000, Status = "Подписан" },
                new Contracts { ContractsId = 5, PhysicalPersonsId = 5, LegalPersonsId = 3, DateOfSign = DateTime.ParseExact("20.09.2020", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 150000, Status = "Подписан" },
                new Contracts { ContractsId = 6, PhysicalPersonsId = 6, LegalPersonsId = 3, DateOfSign = DateTime.ParseExact("11.03.2021", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 335000, Status = "Подписан" },
                new Contracts { ContractsId = 7, PhysicalPersonsId = 7, LegalPersonsId = 4, DateOfSign = DateTime.ParseExact("18.05.2022", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 180000, Status = "Подписан" },
                new Contracts { ContractsId = 8, PhysicalPersonsId = 8, LegalPersonsId = 4, DateOfSign = DateTime.ParseExact("11.07.2022", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 350000, Status = "Подписан" },
                new Contracts { ContractsId = 9, PhysicalPersonsId = 9, LegalPersonsId = 5, DateOfSign = DateTime.ParseExact("01.05.2023", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 75000, Status = "Подписан" },
                new Contracts { ContractsId = 10, PhysicalPersonsId = 10, LegalPersonsId = 5, DateOfSign = DateTime.ParseExact("09.05.2023", "dd.MM.yyyy", CultureInfo.CurrentCulture), ContractSum = 97000, Status = "Подписан" }
            );            
            base.OnModelCreating(modelBuilder);
        }
    }
}
