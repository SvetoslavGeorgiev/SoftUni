namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Robot : Humanoid
    {


        private string model;

        public Robot(string model, string id) : base(id)
        {
            Model = model;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }


    }
}
