using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UcuzSepet.Data.Domain.Entities;

namespace UcuzSepet.Application.API.Models {
    public class OrderItemViewModel {
        public int Id { get; set; }
        [Required]
        public ProductViewModel Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
    }
}
