using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Travel.Services;
using Travel.Services.Integrations.CountryApi.DTO;
using Travel.Services.Interfaces;
using Travel9.ViewModels;

namespace Travel9.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        public async Task<IActionResult> Index()
        {
            var travelVM = new TravelVM { CountryList = await BuildCountryListAsync() };
            return View(travelVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TravelVM travelVM)
        {
            // call DB
            travelVM.CountryList = await BuildCountryListAsync();

            return View(travelVM);
        }

        private async Task<List<SelectListItem>> BuildCountryListAsync()
        {
            try
            {
                var countries = await _travelService.GetCountryAsync() ?? new List<CountryItem>();
                return countries
                    .OrderBy(c => c.Name)
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Code })
                    .DefaultIfEmpty(new SelectListItem { Text = "-- geen landen beschikbaar --", Value = "", Disabled = true, Selected = true })
                    .ToList();
            }
            catch
            {
                return new()
                 {
                     new SelectListItem { Text = "-- landen laden mislukt --", Value = "", Disabled = true, Selected = true }
                 };
            }
        }

        public async Task<IActionResult> IndexWithDatePicker()
        {
            var travelDatePickerVM = new TravelDatePickerVM { CountryList = await BuildCountryListAsync() };
            return View(travelDatePickerVM);
        }

        [HttpPost]
        public async Task<IActionResult> IndexWithDatePicker(TravelDatePickerVM travelDatePickerVM)
        {
            // call DB
            travelDatePickerVM.CountryList = await BuildCountryListAsync();

            return View(travelDatePickerVM);
        }
    }
}
