using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.MVC.Models
{
    public class UserModels
    {
        [Required,  MinLength(1, ErrorMessage = "La taille minum du nom est de 1 caractères")]
        [BindProperty]
        public string LastName { get; set; }
        [Required, MinLength(3, ErrorMessage = "La taille minum du prénom est de 3 caractères")]
        [BindProperty]
        public string FirstName { get; set; }
        [Required, EmailAddress]
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [Required, MinLength(3, ErrorMessage = "La taille minum du mot de passe est de 8 caractères")]
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ConfPdw { get; set; }

    }
}
