using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gq_kp_api.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("brand_id")]
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }

        [Column("sku_code")]
        public string? SkuCode { get; set; }

        [Column("agsk_code")]
        public string? AgskCode { get; set; }

        [Column("product")]
        public string? ProductName { get; set; }

        [Column("price_ex_vat")]
        public decimal? PriceExVat { get; set; }

        [Column("price_inc_vat")]
        public decimal? PriceIncVat { get; set; }

        [Column("uom")]
        public string? UoM { get; set; }

        // Navigation property
        [JsonIgnore]
        public Brand? Brand { get; set; }
    }
}
