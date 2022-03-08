using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table("Experiance")]
    public class Experiance
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poste { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
