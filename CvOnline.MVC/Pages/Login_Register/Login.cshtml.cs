using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CvOnline.MVC.Models;
using CvOnline.MVC.Opts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CvOnline.MVC.Pages
{
    public class LoginModel : PageModel
    {
        private readonly WebApiConnectionOption _webApiConnectionOption;
        [BindProperty]
        public AuthenticateModels Authenticate { get; set; }

        public LoginModel(IOptions<WebApiConnectionOption> opt)
        {
            _webApiConnectionOption = opt.Value;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        string stringData = JsonConvert.SerializeObject(Authenticate);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(_webApiConnectionOption.UrlUser + "/Authenticate", contentData);

                        var result = response.IsSuccessStatusCode;

                        if (result)
                        {
                            string stringJWT = response.Content.ReadAsStringAsync().Result;
                            var jwt = JsonConvert.DeserializeObject<System.IdentityModel.Tokens.Jwt.JwtPayload>(stringJWT);
                            var jwtString = jwt["token"].ToString();

                            HttpContext.Session.SetString("token", jwtString);
                            HttpContext.Session.SetString("firstName", jwt["firstName"].ToString());
                            HttpContext.Session.SetString("lastName", jwt["lastName"].ToString());
                            HttpContext.Session.SetString("email", jwt["email"].ToString());
                        }
                        else
                        {
                            string r = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                }
            }catch (Exception ex)
            {
                ex.ToString();
            }

            return RedirectToPage("../Index");
        }
    }
}
