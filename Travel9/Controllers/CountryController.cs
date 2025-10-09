using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using Travel.Services.Integrations.CountryApi.DTO;
using Travel9.ViewModels;

namespace Travel9.Controllers
{
    public class CountryController : Controller
    {
        private IConfiguration _Configure;
        private string? apiBaseUrl;

        public CountryController(IConfiguration configuration)
        {
            _Configure = configuration;
            apiBaseUrl = _Configure.GetValue<String>("WebAPIBaseUrl");
        }

    public async Task <IActionResult> Index()
        {
            var countryVM = new CountryVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiBaseUrl))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        var root = JsonConvert.DeserializeObject<CountryApiDto>(apiResponse);
                        //   ViewBag.CountryLst = countries != null ? countries.Select(x => new SelectListItem { Text = x.LocalizedName, Value = x.ID }).ToList() : null;
                        var items = root?.Data ?? new List<CountryItem>();
                        countryVM.CountryList = items.Select(c => new SelectListItem
                        {
                            Text = c.Name,
                            Value = c.Code
                        }).ToList(); // LINQ

                    }
                }

            }
            catch (HttpRequestException ex)
            {
                // catch problem

            }
            return View(countryVM);
        }
        [HttpPost]
        public IActionResult Index(CountryVM countryVM)
        {
            return View();
        }
    }
}
