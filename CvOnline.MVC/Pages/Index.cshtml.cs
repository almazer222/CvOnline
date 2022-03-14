using CvOnline.MVC.Models;
using CvOnline.MVC.Opts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CvOnline.MVC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WebApiConnectionOption _webApiConnectionOption;

        public CVModels CvModel { get; set; }



        public IndexModel(ILogger<IndexModel> logger, IOptions<WebApiConnectionOption> opt)
        {
            _webApiConnectionOption = opt.Value;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(_webApiConnectionOption.UrlCV + $"/GetCvItem?id={4}");
                    string apiReponse = await response.Content.ReadAsStringAsync();
                    CvModel = JsonConvert.DeserializeObject<CVModels>(apiReponse);
                }

                CvModel.Experiances.FindAll(e => e.EndDate == new DateTime()).ForEach(e => e.EndDate = DateTime.Today);
                CvModel.Educations.FindAll(e => e.EndDate == new DateTime()).ForEach(e => e.EndDate = DateTime.Today);
            }catch (Exception ex)
            {
                ex.ToString();
            }
            

        }
    }
}
