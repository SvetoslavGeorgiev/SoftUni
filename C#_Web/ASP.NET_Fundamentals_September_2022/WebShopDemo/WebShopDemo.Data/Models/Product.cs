namespace WebShopDemo.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Comment("Products to sell")]
    public class Product
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }
        [Required]
        [Comment("Product name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        [Comment("Product price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Products in stock")]
        public int Quantity { get; set; }

        [Comment("Product is active")]
        public bool IsActive { get; set; } = true;

    }

}
