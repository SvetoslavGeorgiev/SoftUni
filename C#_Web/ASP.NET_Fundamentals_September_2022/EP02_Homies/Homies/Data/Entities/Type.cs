namespace Homies.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Type
    {

        public Type()
        {
            this.Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = null!;

    }


//    •	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 15 (required)
//•	Has Events – a collection of type Event

}
