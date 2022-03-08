using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Box { get; set; }
        public  int PostalCode { get; set; }
        public string Town { get; set; }
        public string Contry { get; set; }
    }
}
