using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.Domain.Enums;

namespace UcuzSepet.Application.Admin.Models {
    public class OrderViewModel {
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
