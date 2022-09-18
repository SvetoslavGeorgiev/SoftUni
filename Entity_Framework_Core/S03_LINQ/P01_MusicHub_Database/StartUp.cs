namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new MusicHubDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
        }

        //public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
