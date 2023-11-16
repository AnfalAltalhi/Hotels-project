﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Cart
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


    }
}
