namespace ExplicitInterfaces.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IResident : IName, ICountry
    {
        string GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
