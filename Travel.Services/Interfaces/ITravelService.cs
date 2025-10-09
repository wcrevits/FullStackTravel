using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Integrations.CountryApi.DTO;

namespace Travel.Services.Interfaces
{
    public interface ITravelService
    {
        Task<List<CountryItem>?> GetCountryAsync();
    }
}
