namespace Homies.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventParticipant
    {
        [Key]
        [ForeignKey(nameof(Helper))]
        [Required]
        public string HelperId { get; set; } = null!;

        [Required]
        public IdentityUser Helper { get; set; } = null!;

        [Required]
        [Key]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        [Required]
        public Event Event { get; set; } = null!;

    }

//    •	HelperId – a string, Primary Key, foreign key(required)
//•	Helper – IdentityUser
//•	EventId – an integer, Primary Key, foreign key(required)
//•	Event – Event

}