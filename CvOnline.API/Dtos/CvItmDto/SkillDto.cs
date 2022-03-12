using System.Collections.Generic;

namespace CvOnline.API.Dtos.CvItmDto
{
    public record SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<SkillItemsDto> SkillItems { get; set; }
    }
}
