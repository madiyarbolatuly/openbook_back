using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gq_kp_api.Models
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Required]
        [Column("brand")]
        public string BrandName { get; set; } = string.Empty;
    }
}
