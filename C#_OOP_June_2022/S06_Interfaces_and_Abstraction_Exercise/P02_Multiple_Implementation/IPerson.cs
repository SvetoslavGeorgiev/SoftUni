namespace PersonInfo
{
    public interface IPerson : IIdentifiable, IBirthable
    {

        public string Name { get; set; }

        public int Age { get; set; }

    }
}