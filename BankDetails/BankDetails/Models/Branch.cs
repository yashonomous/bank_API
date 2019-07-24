using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankDetails.Models
{
    [Table("branches")]
    public class Branch
    {
        [Key]
        public string ifsc { get; set; }
        [ForeignKey("id")]
        public int bank_id { get; set; }
        public string branch { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
    }
}
