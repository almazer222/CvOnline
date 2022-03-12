using CvOnline.Domain.Models;

namespace CvOnline.API.Dtos.CvItmDto
{
    public record IdentityDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KindOfWork { get; set; }
        public AddressDto Address { get; set; }
    }
}
