using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer()
        {

        }

        public Trainer(string name, List<Pokemon> collection)
        {
            Name = name;
            Collection = collection;
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; } = 0;

        public List<Pokemon> Collection { get; set; }
    }
}
