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
using CvOnline.MVC.Opts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CvOnline.MVC.Pages.Login_Register
{
    public class RegisterModel : PageModel
    {
        private readonly WebApiConnectionOption _webApiConnectionOption;
        private readonly IMapper _mappingService;

        public RegisterModel(IMapper mappingService,
                              IOptions<WebApiConnectionOption> opts)
        {
            _webApiConnectionOption = opts.Value;
            _mappingService = mappingService;
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
            if (string.IsNullOrEmpty(Entreprise.Name))
                Entreprise.Name = "EyeTech";
            if (string.IsNullOrEmpty(User.ConfirmPassword))
                User.ConfirmPassword = User.Password;
            if (Address.PostalCode == 0)
                Address.PostalCode = 8500;

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
                        var response = await client.PostAsync(_webApiConnectionOption.UrlUser + "/Register", contentData);
                        var result = response.IsSuccessStatusCode;

                        if (result)
                        {
                            string stringJWT = response.Content.ReadAsStringAsync().Result;
                            var jwt = JsonConvert.DeserializeObject<JwtPayload>(stringJWT);
                            var jwtString = jwt["token"].ToString();

                            HttpContext.Session.SetString("token", jwtString);
                            HttpContext.Session.SetString("firstName", jwt["firstName"].ToString());
                            HttpContext.Session.SetString("lastName", jwt["lastName"].ToString());
                            HttpContext.Session.SetString("email", jwt["email"].ToString());
                        }
                    }

                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return RedirectToPage("../Index");
        }
    }
}
