using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Travel9.ViewModels
{
    public class TravelVM
    {
        [Display(Name = "Departure")]
        public string? DepartureCode { get; set; }
        [Display(Name = "Arrival")]
        public string? ArrivalCode { get; set; }
        
        public List<SelectListItem>? CountryList { get; set; }
        [Display(Name = "Departure date *")]
        [Required(ErrorMessage = "Vertrekdatum moet ingegeven worden")]
        [DataType(DataType.Date)]

        public string? StartDate { get; set; }
        [Display(Name = "Return date *")]
        [Required(ErrorMessage = "Gelieve een einddatum in te geven")]
        [DataType(DataType.Date)]
        public string? EndDate { get; set; }
    }

    public class TravelDatePickerVM
    {
        [Display(Name = "Departure")]
        public string? DepartureCode { get; set; }
        [Display(Name = "Arrival")]
        public string? ArrivalCode { get; set; }

        public List<SelectListItem>? CountryList { get; set; }
        [Display(Name = "Departure date *")]
        [Required(ErrorMessage = "Vertrekdatum moet ingegeven worden")]
        

        public string? StartDate { get; set; }
        [Display(Name = "Return date *")]
        [Required(ErrorMessage = "Gelieve een einddatum in te geven")]
        
        public string? EndDate { get; set; }
    }
}
