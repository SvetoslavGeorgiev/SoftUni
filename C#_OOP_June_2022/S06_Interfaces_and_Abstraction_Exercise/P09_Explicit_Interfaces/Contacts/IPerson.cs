namespace ExplicitInterfaces.Contacts
{
    public interface IPerson : IName, IAge
    {
        string GetName()
        {
            return Name;
        }
    }
}
