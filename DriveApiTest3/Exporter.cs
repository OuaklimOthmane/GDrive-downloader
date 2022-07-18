using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using System.IO;

namespace DriveApiTest3
{
    public class Exporter
    {
        /// <summary>
        /// Download a Document file in PDF format.
        /// </summary>
        /// <param name="fileId">file ID of any workspace document format file.</param>
        /// <returns>byte array stream if successful, null otherwise.</returns>

        public static string DriveDownloadFile(string fileId, string mimeType, string pathServiceAccount, string pathLocalStorage)
        {
           
            try
            {
                var service = Login.serviceCreator(pathServiceAccount);

                var request = service.Files.Export(fileId, mimeType);

                var stream = new MemoryStream();

                // Add a handler which will be notified on progress changes.
                // It will notify on each chunk download and when the download is completed or failed.
                request.MediaDownloader.ProgressChanged +=
                    progress =>
                    {
                        switch (progress.Status)
                        {
                            case DownloadStatus.Downloading:
                                {
                                    Console.WriteLine(progress.BytesDownloaded);
                                    break;
                                }
                            case DownloadStatus.Completed:
                                {
                                    Console.WriteLine("Download complete.");
                                    break;
                                }
                            case DownloadStatus.Failed:
                                {

                                    throw progress.Exception;
                                    break;
                                }
                        }
                    };

                // Request :
                request.Download(stream);
                var fileName = NameGetter.getName(fileId, pathServiceAccount);
            
                var fileStream = File.Create(@pathLocalStorage + fileName + ".csv");
                stream.WriteTo(fileStream);
                fileStream.Close();

                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();

                return text;
            }
            catch (Exception e)
            {
                if (e is AggregateException)
                {
                    Console.WriteLine("Credential Not found");
                }
                else
                {
                    throw;
                }
            }
            return null;
        }
    }
}
