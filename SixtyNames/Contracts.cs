using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public class Contracts
    {
        public int ContractsId { get; set; }
        public int PhysicalPersonsId { get; set; }
        public int LegalPersonsId { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfSign { get; set; }
        public int ContractSum { get; set; }
        public string? Status { get; set; }    }
}
