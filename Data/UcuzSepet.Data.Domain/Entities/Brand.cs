using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcuzSepet.Data.Domain.Entities {
    
    /// <summary>
    /// Brand Entity
    /// </summary>
    [Table("Brands")]
    public class Brand {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
