using DocumentFormat.OpenXml.ExtendedProperties;
using gq_kp_client.Dto;
using gq_kp_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace gq_kp_client.Helpers
{
    internal class HttpHelper
    {
        private static readonly HttpClient client = new HttpClient
        {
            // API base URL
            // BaseAddress = new Uri("http://openbook.gqgroup.kz/")
            BaseAddress = new Uri("http://192.168.2.64:5000/")
            // BaseAddress = new Uri("http://localhost:5000/")
        };

        public async Task<List<Brand>> GetBrandsAsync()
        {
            try
            {
                var brands = await client.GetFromJsonAsync<List<Brand>>("api/brands");
                return brands ?? new List<Brand>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching companies: {ex.Message}");
                return new List<Brand>();
            }
        }


        //public async Task<bool> CreateProductAsync(Product product, string authToken)
        public async Task<bool> CreateProductAsync(Product product)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

            var response = await client.PostAsJsonAsync("api/Products", product);
            return response.IsSuccessStatusCode;
        }


        public async Task<List<ProductDto>> SearchProductAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<ProductDto>();

            string url = $"api/products/search?q={Uri.EscapeDataString(query)}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<ProductDto>>();
            }

            return new List<ProductDto>();
        }
    }
}
