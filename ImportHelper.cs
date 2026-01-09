using ClosedXML.Excel;
using gq_kp_client.Dto;
using gq_kp_client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gq_kp_client.Helpers
{
    public class ImportHelper
    {
        public static void ImportProducts()
        {

        }

        //private static Dictionary<string, int>? _brandDictionary;

        //public static void Initialize(List<Brand> brands)
        //{
        //    _brandDictionary = brands
        //        .ToDictionary(
        //            b => b.BrandName.ToLower(), // case-insensitive
        //            b => b.Id
        //        );
        //}

        //public static int? GetBrandId(string brandName)
        //{
        //    if (_brandDictionary == null)
        //        throw new InvalidOperationException("Brand cache not initialized. Call Initialize() first.");

        //    if (_brandDictionary.TryGetValue(brandName.ToLower(), out int id))
        //        return id;

        //    return null; // not found
        //}

        public static List<ProductDto> ReadProductsFromExcel(string filePath, IProgress<int>? progress = null)
        {
            var products = new List<ProductDto>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.First();
                int startRow = 2;
                int lastRow = worksheet.LastRowUsed().RowNumber();
                int totalRows = lastRow - (startRow - 1);

                for (int row = startRow; row <= lastRow; row++)
                {
                    var brandNameCell = worksheet.Cell(row, 1);
                    if (brandNameCell.IsEmpty())
                        continue;

                    //var priceExVat = worksheet.Cell(row, 6);
                    //var priceIncVat = worksheet.Cell(row, 7);
                    //Debug.WriteLine($"priceExVat = {priceExVat}");
                    //Debug.WriteLine($"priceIncVat = {priceIncVat}");

                    var product = new ProductDto
                    {
                        //BrandId = brandIdCell.GetValue<int>(),
                        BrandName = brandNameCell.GetValue<string>(),
                        SkuCode = worksheet.Cell(row, 2).GetValue<string?>(),
                        AgskCode = worksheet.Cell(row, 3).GetValue<string?>(),
                        ProductName = worksheet.Cell(row, 4).GetValue<string?>(),
                        UoM = worksheet.Cell(row, 5).GetValue<string?>(),
                        PriceExVat = worksheet.Cell(row, 6).GetValue<decimal?>(),
                        PriceIncVat = worksheet.Cell(row, 7).GetValue<decimal?>()
                    };

                    Debug.WriteLine(product.AgskCode);
                    Debug.WriteLine(product.PriceExVat);
                    Debug.WriteLine(product.PriceIncVat);

                    products.Add(product);

                    // Report progress
                    int processed = row - (startRow - 1);
                    int percent = (int)((double)processed / totalRows * 100);
                    progress?.Report(percent);
                }
            }

            return products;
        }
    }
}
