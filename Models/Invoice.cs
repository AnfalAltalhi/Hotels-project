﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdHotel { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdRoomDetails { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime DateInvoice { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public double Net { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }

    }
}