using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.MVC.Models
{
    public class EntrepriseModels
    { 
        [BindProperty]
        [Required]
        public string Name { get; set; }
    }
}
