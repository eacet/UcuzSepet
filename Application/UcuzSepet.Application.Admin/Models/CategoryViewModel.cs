using System.ComponentModel.DataAnnotations;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.Admin.Models {
    public class CategoryViewModel {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Category RootCategory { get; set; }
    }
}
