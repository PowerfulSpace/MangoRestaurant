namespace PS.MangoRestaurant.Web
{
    public static class SD
    {
        public static string ProductAPIBase { get; set; } = null!;
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
