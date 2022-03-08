using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table("SkillItem", Schema = "dbo")]
    public class SkillItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        [InverseProperty(nameof(Skill.SkillItems))]
        public Skill Skill_Tab { get; set; }
    }
}
