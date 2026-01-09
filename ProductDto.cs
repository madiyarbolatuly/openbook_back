namespace gq_kp_api.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? SkuCode { get; set; }
        public string? AgskCode { get; set; }
        public string? ProductName { get; set; }
        public string? Uom { get; set; }
        public decimal? PriceExVat { get; set; }
        public decimal? PriceIncVat { get; set; }
    }
}
