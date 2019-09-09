using System.ComponentModel.DataAnnotations;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.Admin.Models {

    /// <summary>
    /// Category Entity View Model
    /// </summary>
    public class CategoryViewModel {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
