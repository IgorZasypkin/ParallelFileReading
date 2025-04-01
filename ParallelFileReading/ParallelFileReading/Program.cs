using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Пример для 3 файлов
        string[] filePaths = { "C:\\Student\\ParallelFileReading\\file1.txt", "C:\\Student\\ParallelFileReading\\file2.txt", "C:\\Student\\ParallelFileReading\\file3.txt" };

        var stopwatch = Stopwatch.StartNew();
        int totalSpaces = await CountSpacesInFilesAsync(filePaths);
        stopwatch.Stop();

        Console.WriteLine($"Total spaces: {totalSpaces}");
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");

        // Пример для папки
        string folderPath = @"C:\Student\ParallelFileReading\ParallelFileReading\Helper";

        stopwatch.Restart();
        int folderSpaces = await CountSpacesInFolderAsync(folderPath);
        stopwatch.Stop();

        Console.WriteLine($"Total spaces in folder: {folderSpaces}");
        Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Функция для подсчета пробелов в нескольких файлах
    static async Task<int> CountSpacesInFilesAsync(string[] filePaths)
    {
        var tasks = filePaths.Select(filePath => CountSpacesInFileAsync(filePath));
        int[] results = await Task.WhenAll(tasks);
        return results.Sum();
    }

    // Функция для подсчета пробелов в файле
    static async Task<int> CountSpacesInFileAsync(string filePath)
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

    // Функция для подсчета пробелов во всех файлах папки
    static async Task<int> CountSpacesInFolderAsync(string folderPath)
    {
        try
        {
            string[] files = Directory.GetFiles(folderPath);
            return await CountSpacesInFilesAsync(files);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing folder {folderPath}: {ex.Message}");
            return 0;
        }
    }
}