using System.ComponentModel.DataAnnotations.Schema;

namespace PS.MangoRestaurant.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        public int CartDetailsId { get; set; }

        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; } = null!;

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        public int Count { get; set; }
    }
}
