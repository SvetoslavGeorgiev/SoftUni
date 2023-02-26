namespace P02_FootballBetting.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {

        public Country()
        {
            Towns = new HashSet<Town>();
        }

        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}