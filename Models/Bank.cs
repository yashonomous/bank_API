
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDetails.Models
{
    [Table("banks")]
    public class Bank
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
