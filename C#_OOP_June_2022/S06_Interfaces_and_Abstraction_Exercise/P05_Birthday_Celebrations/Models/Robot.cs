namespace BirthdayCelebrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Robot : Humanoid
    {


        private string model;
        private string id;
        public Robot(string model, string id) : base("0")
        {
            Model = model;
            Id = id;
        }

        public string Model
        {
            get => model;
            private set
            {
                model = value;
            }
        }

        public string Id
        {
            get => id;
            private set
            {
                id = value;
            }
        }
    }
}
