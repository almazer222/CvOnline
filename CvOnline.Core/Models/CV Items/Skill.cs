using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table ("Skill")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(SkillItem.Skill_Tab))]
        public ICollection<SkillItem> SkillItems { get; set; }

        public int CvId { get; set; }
        [ForeignKey(nameof(CvId))]
        [InverseProperty(nameof(CV.Skills))]
        public CV  Cv { get; set; }

    }
}
