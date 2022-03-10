using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table ("Certification")]
    public class Certification
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CvId { get; set; }
        [ForeignKey(nameof(CvId))]
        [InverseProperty(nameof(CvItems.Certifications))]
        public CvItems Cv { get; set; }
    }
}
