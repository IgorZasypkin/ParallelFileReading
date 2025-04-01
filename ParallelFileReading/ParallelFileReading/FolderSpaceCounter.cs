using ParallelFileReading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileReading
{
    public class FolderSpaceCounter : IFolderSpaceCounter
    {
        private readonly IFileSpaceCounter _fileCounter;
        private readonly string _folderPath;

        public FolderSpaceCounter(IFileSpaceCounter fileCounter, string folderPath)
        {
            _fileCounter = fileCounter ?? throw new ArgumentNullException(nameof(fileCounter));
            _folderPath = folderPath ?? throw new ArgumentNullException(nameof(folderPath));
        }

        public async Task<int> CountSpacesAsync() => await CountSpacesInFolderAsync(_folderPath);

        public async Task<int> CountSpacesInFolderAsync(string folderPath)
        {
            try
            {
                var files = Directory.GetFiles(folderPath);
                return await _fileCounter.CountSpacesInFilesAsync(files);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing folder {folderPath}: {ex.Message}");
                return 0;
            }
        }
    }
}
