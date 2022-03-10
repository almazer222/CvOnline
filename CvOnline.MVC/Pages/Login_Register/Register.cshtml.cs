using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CvOnline.MVC.Dtos;
using CvOnline.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CvOnline.MVC.Pages.Login_Register
{
    public class RegisterModel : PageModel
    {
        private readonly IConfiguration _Config;
        private readonly IMapper _mappingService;
        private string urlBase
        {
            get { return _Config.GetSection("BaseUrl").GetSection("URL").Value; }
        }

        #region Properties
        [BindProperty]
        public new UserModels User { get; set; }
        [BindProperty]
        public EntrepriseModels Entreprise { get; set; }
        [BindProperty]
        public AddressModels Address { get; set; }
        #endregion


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            var user = _mappingService.Map<UserModels, UserDto>(User);
                            user.Entreprise = _mappingService.Map<EntrepriseModels, EntrepriseDto>(Entreprise);
                            user.Entreprise.Address = _mappingService.Map<AddressModels, AddressDto>(Address);

                            string stringData = JsonConvert.SerializeObject(user);
                            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                            var response = await client.PostAsync(urlBase + "User/register", contentData);
                            var result = response.IsSuccessStatusCode;

                            if (result)
                            {
                                string stringJWT = response.Content.ReadAsStringAsync().Result;
                                var jwt = JsonConvert.DeserializeObject<JwtPayload>(stringJWT);
                                var jwtString = jwt["token"].ToString();

                                HttpContext.Session.SetString("token", jwtString);//username
                                HttpContext.Session.SetString("username", jwt["username"].ToString());
                            }
                        }
                   
                    }catch(Exception)
                    {

                    }
                }

            }
            return Page();
        }
    }
}
