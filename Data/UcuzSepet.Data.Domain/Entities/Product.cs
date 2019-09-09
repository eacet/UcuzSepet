using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcuzSepet.Data.Domain.Entities {
    /// <summary>
    /// Product Entity
    /// </summary>
    [Table("Products")]
    public class Product {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Properties { get; set; }

        public SubCategory SubCategory { get; set; }
        public Brand Brand { get; set; }
    }
}
