using DriveApiProject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DriveApiTest3
{
    class DownloadFile
    {
        public static void DriveDownloadFile()
        {
            // 1. Create a service collection for DI
            var serviceCollection = new ServiceCollection();

            // 2. Build a configuaration :
            IConfiguration configuration;
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName).AddJsonFile("appsettings.json").Build();

            // 3. Add the configuration to the service collection :
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<DataGetter>();

            // 4. Get data :
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testInstance = serviceProvider.GetService<DataGetter>();
            var (pathServiceAccount, fileId, mimeType, pathLocalStorage, newPathLocalStorage) = testInstance.TestMethod();

            // 5. Download the file :
            Exporter.DriveDownloadFile(fileId, mimeType, pathServiceAccount, pathLocalStorage);

            // 6. Convert the file from csv to xls :
            Converter.CsvConverter(fileId, pathServiceAccount, pathLocalStorage, newPathLocalStorage);
        }
    }
}
