using System;

namespace CvOnline.MVC.Models
{
    public class EducationModels
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string KindOfStudy { get; set; }
        public string Degres  { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
