using PS.MangoRestaurant.Web.Models;

namespace PS.MangoRestaurant.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        public ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
