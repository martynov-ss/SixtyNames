using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp1
{
    public class PhysicalPersons
    {       
        public int PhysicalPersonsId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Job { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
    }
}
