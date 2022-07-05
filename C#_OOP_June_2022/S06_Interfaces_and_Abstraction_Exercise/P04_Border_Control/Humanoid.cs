namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Humanoid
    {
        private string id;
        protected Humanoid(string id)
        {
            Id = id;
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
