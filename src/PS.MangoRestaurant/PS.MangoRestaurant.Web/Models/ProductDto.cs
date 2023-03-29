using System.ComponentModel.DataAnnotations;

namespace PS.MangoRestaurant.Web.Models
{
    public class ProductDto
    {
        public ProductDto()
        {
            Count = 1;
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [Range(1,100)]
        public int Count { get; set; }
    }
}
