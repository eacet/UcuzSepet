using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UcuzSepet.Data.Domain.Enums;

namespace UcuzSepet.Application.API.Models {
    /// <summary>
    /// Order View Model
    /// </summary>
    public class OrderViewModel {
        public int Id { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
