using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models
{
    [Table("Entreprise")]
    public class Entreprise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Clé étrangére
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
