namespace details.Client.Services
{
    using details.Shared;
    using System.Collections.Generic;

    public class CartService
    {
        private List<HotelRoom> _cartItems;

        public CartService()
        {
            _cartItems = new List<HotelRoom>();
        }

        public void AddToCart(HotelRoom hotelRoom)
        {
            _cartItems.Add(hotelRoom);
        }

        public List<HotelRoom> GetCartItems()
        {
            return _cartItems;
        }
    }
}
