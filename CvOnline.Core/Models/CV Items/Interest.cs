using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table("Interest")]
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CvId { get; set; }
        [ForeignKey(nameof(CvId))]
        [InverseProperty(nameof(CV.Interests))]
        public CV Cv { get; set; }

    }
}
