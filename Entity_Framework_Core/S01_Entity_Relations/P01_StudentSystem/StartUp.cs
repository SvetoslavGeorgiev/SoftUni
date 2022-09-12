namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    using System;

    public class StartUp
    {
        static void Main()
        {

            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();


        }
    }
}
