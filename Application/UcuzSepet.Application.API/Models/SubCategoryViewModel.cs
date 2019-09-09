using System.ComponentModel.DataAnnotations;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.API.Models {
    public class SubCategoryViewModel {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public Category RootCategory { get; set; }
    }
}
