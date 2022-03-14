namespace CvOnline.MVC.Models
{
    public class IdentityModels
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string KindOfWork { get; set; }
        public AddressModels Address { get; set; }
    }
}
