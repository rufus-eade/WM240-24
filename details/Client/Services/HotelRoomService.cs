namespace details.Client.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using details.Shared;
    using System.Text;

    public class HotelRoomService
    {
        private readonly HttpClient _httpClient;

        public HotelRoomService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _httpClient.GetFromJsonAsync<List<HotelRoom>>("api/HotelRooms");
        }

        public async Task<HotelRoom> GetHotelRoom(int id)
        {
            return await _httpClient.GetFromJsonAsync<HotelRoom>($"api/HotelRooms/{id}");
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCart()
        {
            return await _httpClient.GetFromJsonAsync<List<ShoppingCartItem>>("api/HotelRooms/ShoppingCart");
        }

        public async Task AddToCart(int roomId)
        {
            var content = new StringContent("", Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"api/HotelRooms/AddToCart/{roomId}", content);
        }

        public async Task RemoveFromCart(int shoppingCartItemId)
        {
            await _httpClient.DeleteAsync($"api/HotelRooms/RemoveFromCart/{shoppingCartItemId}");
        }
    }
}

