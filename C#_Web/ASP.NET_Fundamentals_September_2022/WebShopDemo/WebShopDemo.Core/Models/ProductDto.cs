namespace WebShopDemo.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Product Identidier
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Product name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Product price
        /// </summary>
        [Range(typeof(decimal), "0.1", "1000", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }


        /// <summary>
        /// Product in stock
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }


    }
}
