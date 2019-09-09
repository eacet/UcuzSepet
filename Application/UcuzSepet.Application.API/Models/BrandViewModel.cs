using System.ComponentModel.DataAnnotations;

namespace UcuzSepet.Application.API.Models {
    /// <summary>
    /// Brand View Model
    /// </summary>
    public class BrandViewModel {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string BrandName { get; set; }
    }
}
