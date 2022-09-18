namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            var album = ExportAlbumsInfo(context, 9);

            Console.WriteLine(album);
            
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var sb = new StringBuilder();


            var allAlbumsForProducer = context
                .Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                          .Select(s => new
                          {
                              SongName = s.Name,
                              Price = s.Price,
                              SongWriterName = s.Writer.Name,
                          })
                          .OrderByDescending(s => s.SongName)
                          .ThenBy(s => s.SongWriterName)
                          .ToList(),
                    Price = a.Price
                })
                .ToList();

            
            foreach (var album in allAlbumsForProducer.OrderByDescending(x => x.Price))
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                var counter = 0;
                foreach (var song in album.Songs)
                {
                    counter++;
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().TrimEnd();



        }

        //public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
