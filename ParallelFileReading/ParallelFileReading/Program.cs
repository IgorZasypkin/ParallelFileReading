using Microsoft.Extensions.DependencyInjection;
using ParallelFileReading;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Настройка DI
        var serviceProvider = DependencyInjection.ConfigureServices();

        // Получение сервиса
        var service = serviceProvider.GetRequiredService<SpaceCounterService>();

        // Запуск операций
        await service.RunFileCountAsync();
        await service.RunFolderCountAsync();

        // Очистка (для реальных приложений)
        if (serviceProvider is IDisposable disposable)
            disposable.Dispose();
    }
}