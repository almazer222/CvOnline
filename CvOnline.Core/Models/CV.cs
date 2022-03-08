using CvOnline.Core.Models;
using CvOnline.Domain.Models.CV_Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Models
{
    [Table("CV")]
    public class CV
    {
        [Key]
        public int Id { get; set; }
        public int IdentityId { get; set; }
        public Identity  Identity { get; set; }
        [InverseProperty(nameof(SkillItem.Skill_Tab))]
        public ICollection<int> SocialsId { get; set; }
        [InverseProperty(nameof(SkillItem.Skill_Tab))]
        public ICollection<Social> Socials { get; set; }
        public ICollection<int> ExperiancesId { get; set; }
        public ICollection<Experiance> Experiances { get; set; }
        public ICollection<int> SkillsId { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<int> InterestsId { get; set; }
        public ICollection<Interest> Interests { get; set; }
        public ICollection<int> CertificationsId { get; set; }
        public ICollection<Certification> Certifications { get; set; }
        
    }
}
