using System.Collections.Generic;

namespace CvOnline.MVC.Models
{
    public class CVModels
    {
        public int Id { get; set; }

        public IdentityModels  Identity { get; set; }
        public List<SkillModels> Skills { get; set; }
        public List<SocialModels> Socials { get; set; }
        public List<ExperianceModels> Experiances { get; set; }
        public List<EducationModels> Educations { get; set; }
        public List<InterestModels> Interests { get; set; }
        public List<CertificationModels> Certifications { get; set; }
        
    }
}
