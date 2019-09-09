using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UcuzSepet.Data.Domain.Enums;

namespace UcuzSepet.Data.Domain.Entities {

    /// <summary>
    /// Order Entity
    /// </summary>
    [Table("Orders")]
    public class Order {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public ICollection<OrderItem> Items { get; set; }
    }
}
