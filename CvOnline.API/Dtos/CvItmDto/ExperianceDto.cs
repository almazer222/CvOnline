using System;

namespace CvOnline.API.Dtos.CvItmDto
{
    public record ExperianceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Poste { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
    }
}
