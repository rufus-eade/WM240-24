using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace details.Shared
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId { get; set; }

        [ForeignKey("HotelRoom")]
        public int HotelRoomId { get; set; }

        public HotelRoom HotelRoom { get; set; }

        public int Quantity { get; set; }
    }
}
