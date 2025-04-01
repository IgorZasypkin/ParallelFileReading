using Microsoft.Extensions.DependencyInjection;
using ParallelFileReading.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileReading
{
    public static class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Конфигурация
            string[] filePaths = { "C:\\Student\\ParallelFileReading\\file1.txt", "C:\\Student\\ParallelFileReading\\file2.txt", "C:\\Student\\ParallelFileReading\\file3.txt" };
            string folderPath = @"C:\Student\ParallelFileReading\ParallelFileReading\Helper";

            // Регистрация сервисов
            services.AddSingleton<IFileSpaceCounter>(_ => new FileSpaceCounter(filePaths));
            services.AddSingleton<IFolderSpaceCounter>(provider =>
                new FolderSpaceCounter(
                    provider.GetRequiredService<IFileSpaceCounter>(),
                    folderPath));

            services.AddSingleton<SpaceCounterService>();

            return services.BuildServiceProvider();
        }
    }
}
