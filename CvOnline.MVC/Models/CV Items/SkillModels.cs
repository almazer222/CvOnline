using System.Collections.Generic;

namespace CvOnline.MVC.Models
{
    public class SkillModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SkillItemModels> SkillItems { get; set; }
    }
}
