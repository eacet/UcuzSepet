using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcuzSepet.Data.Domain.Entities {

    /// <summary>
    /// Sub Category Entity
    /// </summary>
    [Table("SubCategories")]
    public class SubCategory {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int RootCategoryId { get; set; }
        public Category RootCategory { get; set; }
    }
}
