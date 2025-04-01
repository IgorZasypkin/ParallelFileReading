using ParallelFileReading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileReading
{
    public class FileSpaceCounter : IFileSpaceCounter
    {
        private readonly IEnumerable<string> _filePaths;

        public FileSpaceCounter(IEnumerable<string> filePaths)
        {
            _filePaths = filePaths ?? throw new ArgumentNullException(nameof(filePaths));
        }

        public async Task<int> CountSpacesAsync() => await CountSpacesInFilesAsync(_filePaths);

        public async Task<int> CountSpacesInFileAsync(string filePath)
        {
            try
            {
                string content = await File.ReadAllTextAsync(filePath);
                return content.Count(c => c == ' ');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {filePath}: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> CountSpacesInFilesAsync(IEnumerable<string> filePaths)
        {
            var tasks = filePaths.Select(CountSpacesInFileAsync);
            return (await Task.WhenAll(tasks)).Sum();
        }
    }
}
