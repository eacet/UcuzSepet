using System.ComponentModel.DataAnnotations;

namespace UcuzSepet.Application.API.Models {
    public class CategoryViewModel {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
