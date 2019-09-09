using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcuzSepet.Application.API.Models {
    /// <summary>
    ///  Order Item View Model
    /// </summary>
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
