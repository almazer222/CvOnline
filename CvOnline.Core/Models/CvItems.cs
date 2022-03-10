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
    public class CvItems
    {
        [Key]
        public int Id { get; set; }

        [InverseProperty(nameof(Identity.Cv))]
        public Identity  Identities { get; set; }
        [InverseProperty(nameof(Skill.Cv))]
        public ICollection<Skill> Skills { get; set; }
        [InverseProperty(nameof(Social.Cv))]
        public ICollection<Social> Socials { get; set; }
        [InverseProperty(nameof(Experiance.Cv))]
        public ICollection<Experiance> Experiances { get; set; }
        [InverseProperty(nameof(Interest.Cv))]
        public ICollection<Interest> Interests { get; set; }
        [InverseProperty(nameof(Certification.Cv))]
        public ICollection<Certification> Certifications { get; set; }
        
    }
}
