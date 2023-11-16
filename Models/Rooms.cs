using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }

		[Required]
        [StringLength(35)]
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(100)]
        public string Images { get; set; }
        [Required]
        public int RoomNum { get; set; }
        [Required]
        public int IdHotel { get; set; }

        
    }
}
