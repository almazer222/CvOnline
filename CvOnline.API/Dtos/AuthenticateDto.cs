using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.API.Ressources
{
    public class AuthenticateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
