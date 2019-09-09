using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.API.Models {
    public class ProductViewModel {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        public Category ProductCategory { get; set; }
        [Required]
        public Brand ProductBrand { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        public string ProductProperties { get; set; }
    }
}
