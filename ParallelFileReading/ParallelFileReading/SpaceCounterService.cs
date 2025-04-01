using ParallelFileReading.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileReading
{
    public class SpaceCounterService
    {
        private readonly IFileSpaceCounter _fileCounter;
        private readonly IFolderSpaceCounter _folderCounter;
        private readonly Stopwatch _stopwatch;

        public SpaceCounterService(
            IFileSpaceCounter fileCounter,
            IFolderSpaceCounter folderCounter)
        {
            _fileCounter = fileCounter;
            _folderCounter = folderCounter;
            _stopwatch = new Stopwatch();
        }

        public async Task RunFileCountAsync()
        {
            Console.WriteLine("Counting spaces in files...");
            _stopwatch.Restart();
            int totalSpaces = await _fileCounter.CountSpacesAsync();
            _stopwatch.Stop();
            PrintResults(totalSpaces);
        }

        public async Task RunFolderCountAsync()
        {
            Console.WriteLine("Counting spaces in folder...");
            _stopwatch.Restart();
            int totalSpaces = await _folderCounter.CountSpacesAsync();
            _stopwatch.Stop();
            PrintResults(totalSpaces);
        }

        private void PrintResults(int spacesCount)
        {
            Console.WriteLine($"Total spaces: {spacesCount}");
            Console.WriteLine($"Time elapsed: {_stopwatch.ElapsedMilliseconds} ms\n");
        }
    }
}
