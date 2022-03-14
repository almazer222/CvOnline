using System;

namespace CvOnline.MVC.Models
{
    public class ExperianceModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poste { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
