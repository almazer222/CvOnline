using CvOnline.API.Dtos.CvItmDto;
using CvOnline.Domain.Models.CV_Items;
using System.Collections.Generic;

namespace CvOnline.API.Dtos
{
    public record CvItemsDto
    {
        public IdentityDto Identity { get; set; }
        public IEnumerable<SkillDto> Skills { get; set; }
        public IEnumerable<SocialDto> Socials { get; set; }
        public IEnumerable<EducationDto> Educations { get; set; }
        public IEnumerable<ExperianceDto> Experiances { get; set; }
        public IEnumerable<InterestDto> Interests { get; set; }
        public IEnumerable<CertificationDto> Certifications { get; set; }
    }
}
