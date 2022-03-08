using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.MVC.Models
{
    public class AddressModels
    {
        [BindProperty]
        public string Street { get; set; }
        [BindProperty]
        public int Number { get; set; }
        [BindProperty]
        public string Box { get; set; }
        [BindProperty]
        public int PostalCode { get; set; }
        [BindProperty]
        public string Town { get; set; }
        [BindProperty]
        public string Contry { get; set; }
    }
}
