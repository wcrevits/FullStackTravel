using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Integrations.CountryApi.DTO;
using Travel.Services.Interfaces;

namespace Travel.Services
{
    public class TravelService : ITravelService
    {
        private IConfiguration _configure;
        private string? apiBaseUrl;

        public TravelService(IConfiguration configuration)
        {
            _configure = configuration;
            apiBaseUrl = _configure["WebAPIBaseUrl"];
        }

        public async Task<List<CountryItem>?> GetCountryAsync()
        {
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
                        return items;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                // catch problem
                return null;
            }

        }
    }
}
