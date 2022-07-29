namespace CarRacing.Models.Maps.Contracts
{
    using Racers.Contracts;

    public interface IMap
    {
        string StartRace(IRacer racerOne, IRacer racerTwo);
    }
}
