using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcuzSepet.Data.Domain.Entities {

    /// <summary>
    /// Category Entity
    /// </summary>
    [Table("Categories")]
    public class Category {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
