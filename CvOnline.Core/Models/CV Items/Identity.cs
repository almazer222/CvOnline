using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvOnline.Domain.Models.CV_Items
{
    [Table("Identity")]
    public class Identity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string KindOfWork { get; set; }

        public int AdressId { get; set; }

        [ForeignKey(nameof(AdressId))]
        public Address Address { get; set; }

        public int CvId { get; set; }
        [ForeignKey(nameof(CvId))]
        [InverseProperty(nameof(CvItems.Identities))]
        public CvItems Cv { get; set; }

    }
}
