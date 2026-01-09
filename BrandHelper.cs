using gq_kp_client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gq_kp_client.Helpers
{
    public class BrandHelper
    {
        private static Dictionary<string, int>? _brandDictionary;

        public static void Initialize(List<Brand> brands)
        {
            _brandDictionary = brands
                .ToDictionary(
                    b => b.BrandName.ToLower(), // case-insensitive
                    b => b.Id
                );
        }

        public static int? GetBrandId(string brandName)
        {
            if (_brandDictionary == null)
                throw new InvalidOperationException("Brand cache not initialized. Call Initialize() first.");

            if (_brandDictionary.TryGetValue(brandName.ToLower(), out int id))
                return id;

            return null; // not found
        }
    }
}
