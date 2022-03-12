namespace CvOnline.API.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Box { get; set; }
        public int PostalCode { get; set; }
        public string Town { get; set; }
        public string Contry { get; set; }
    }
}
