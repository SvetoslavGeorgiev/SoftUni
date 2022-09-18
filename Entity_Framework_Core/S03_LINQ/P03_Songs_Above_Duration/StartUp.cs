namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var context = new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            var album = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(album);
            
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {

            var sb = new StringBuilder();

            var allSongs = context
                .Songs
                .Include(s => s.SongPerformers)
                .ThenInclude(sp => sp.Performer)
                .Include(s => s.Writer)
                .Include(s => s.Album)
                .ThenInclude(a => a.Producer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    WriterName = s.Writer.Name,
                    Performer = s.SongPerformers
                         .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                         .FirstOrDefault(),
                    ProduserName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.Performer)
                .ToList();

            var counter = 0;

            foreach (var s in allSongs)
            {
                counter++;

                sb.AppendLine($"-Song #{counter}")
                    .AppendLine($"---SongName: {s.Name}")
                    .AppendLine($"---Writer: {s.WriterName}")
                    .AppendLine($"---Performer: {s.Performer}")
                    .AppendLine($"---AlbumProducer: {s.ProduserName}")
                    .AppendLine($"---Duration: {s.Duration}");
            }



            return sb.ToString().TrimEnd();
                
        }

        //public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        //{

        //    var sb = new StringBuilder();


        //    var allAlbumsForProducer = context
        //        .Albums
        //        .Where(a => a.ProducerId.Value == producerId)
        //        .Include(a => a.Producer)
        //        .Include(a => a.Songs)
        //        .ThenInclude(s => s.Writer)
        //        .ToList()
        //        .Select(a => new
        //        {
        //            AlbumName = a.Name,
        //            ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
        //            ProducerName = a.Producer.Name,
        //            Songs = a.Songs
        //                  .Select(s => new
        //                  {
        //                      SongName = s.Name,
        //                      Price = s.Price,
        //                      SongWriterName = s.Writer.Name,
        //                  })
        //                  .OrderByDescending(s => s.SongName)
        //                  .ThenBy(s => s.SongWriterName)
        //                  .ToList(),
        //            ToatalPrice = a.Price
        //        })
        //        .OrderByDescending(x => x.ToatalPrice)
        //        .ToList();


        //    foreach (var album in allAlbumsForProducer)
        //    {
        //        sb.AppendLine($"-AlbumName: {album.AlbumName}")
        //          .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
        //          .AppendLine($"-ProducerName: {album.ProducerName}")
        //          .AppendLine($"-Songs:");
        //        var counter = 0;
        //        foreach (var song in album.Songs)
        //        {
        //            counter++;
        //            sb.AppendLine($"---#{counter}")
        //              .AppendLine($"---SongName: {song.SongName}")
        //              .AppendLine($"---Price: {song.Price:F2}")
        //              .AppendLine($"---Writer: {song.SongWriterName}");
        //        }


        //        sb.AppendLine($"-AlbumPrice: {album.ToatalPrice:F2}");
        //    }

        //    return sb.ToString().TrimEnd();



        //}


    }
}
