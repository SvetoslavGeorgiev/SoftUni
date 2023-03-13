namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.CategoriesProducts = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }
    }
}
