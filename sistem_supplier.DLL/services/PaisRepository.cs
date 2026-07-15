using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using sistem_supplier.DTO;
using sistem_supplier.DLL.services.conexion;
using System.Linq;

namespace sistem_supplier.DLL.services
{
    public class PaisRepository: IPaisRepository
    {
        private readonly HttpClient _httpClient;

        public PaisRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PaisDTO>> GetAllPais()
        {
            var response = await _httpClient.GetAsync(
                "https://restcountries.com/v3.1/all");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<CountryResponse>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (data == null)
            {
                return new List<PaisDTO>();
            }

            return data.Select(x => new PaisDTO
            {
                Name = x.Name.Common
            }).ToList();
        }
        public class CountryResponse
        {
            public NameData Name { get; set; }
        }

        public class NameData
        {
            public string Common { get; set; }
        }
    }
}
