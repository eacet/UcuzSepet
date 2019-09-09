using System.ComponentModel.DataAnnotations;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.API.Models {
    /// <summary>
    /// Sub Category View Model
    /// </summary>
    public class SubCategoryViewModel {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string SubCategoryName { get; set; }
        public Category RootCategory { get; set; }
    }
}
