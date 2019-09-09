using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.Admin.Models {
    public class ProductViewModel {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Properties { get; set; }

        public SubCategory SubCategory { get; set; }
        public Brand Brand { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

    }
}
