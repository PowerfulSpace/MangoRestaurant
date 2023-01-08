using PS.MangoRestaurant.Web.Models;

namespace PS.MangoRestaurant.Web.Services.IServices
{
    public interface IProductServices
    {
        Task<T> GetProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
