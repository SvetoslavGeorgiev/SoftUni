namespace PlanetWars.IO.Contracts
{
    interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
