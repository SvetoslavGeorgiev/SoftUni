namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
	    public int Id { get; set; }

		[Required]
	    public string Name { get; set; }

	    public ICollection<Item> Items { get; set; }
    }
}
