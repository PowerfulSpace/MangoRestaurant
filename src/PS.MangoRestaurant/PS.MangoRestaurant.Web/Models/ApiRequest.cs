using static PS.MangoRestaurant.Web.SD;

namespace PS.MangoRestaurant.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = null!;
        public object Data { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
    }
}
