using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace music_organizer.Actions
{
    public class OrderByAlbumYearAction
    {
        private string Path { get; set; }
        public OrderByAlbumYearAction(string path)
        {
            this.Path = path;
        }

        public void Run()
        {
            var files = Directory.GetFiles(this.Path);
            Console.WriteLine($"{files.Count()} files ecnountered in the path.");

            var amountIncompatibleFiles = 0;
            var unorderedFiles = new List<object>();

            foreach (var file in files)
            {
                try
                {
                    var tfile = TagLib.File.Create(file);

                    var newUnderoderedFile = new {
                        AlbumYear = tfile.Tag.Year,
                        AlbumName = tfile.Tag.Album,
                        MusicName = tfile.Tag.Title,
                        FilePath = file
                    };

                    unorderedFiles.Add(newUnderoderedFile);
                }
                catch (Exception ex)
                {
                    amountIncompatibleFiles++;
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            var orderedFiles = unorderedFiles.OrderBy(file => ((dynamic)file).AlbumYear).ToArray();

            for (int i = 0; i < orderedFiles.Count(); i++)
            {
                var currentFile = (dynamic)orderedFiles[i];
                var newFileName= $"{i + 1} - {currentFile.AlbumYear} - {currentFile.MusicName}.mp3";
                var newFilePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(currentFile.FilePath), newFileName);

                File.Move(currentFile.FilePath, newFilePath);
            }

            Console.WriteLine($"{files.Count() - amountIncompatibleFiles} files were ordered by album year.");
        }
    }
}
