using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.API.Ressources
{
    public class EntrepriseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
