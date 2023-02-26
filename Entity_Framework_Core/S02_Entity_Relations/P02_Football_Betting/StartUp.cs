namespace P02_FootballBetting
{
    using P02_FootballBetting.Data;
    using System;

    public class StartUp
    {
        static void Main()
        {
            var db = new FootballBettingContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

        }
    }
}
