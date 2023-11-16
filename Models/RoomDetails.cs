using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotels.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Image1 { get; set; }
        [Required]
        [StringLength(100)]
        public string Image2 { get; set; }
        [Required]
        [StringLength(100)]
        public string Image3 { get; set; }
        [Required]
        [StringLength(50)]
        public string Food { get; set; }
        [Required]
        [StringLength(100)]
        public string Futures { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdHotel { get; set; }


    }
}
