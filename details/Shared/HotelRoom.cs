using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace details.Shared
{
    public class HotelRoom
    {
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public bool InCart { get; set; }
    }
}
