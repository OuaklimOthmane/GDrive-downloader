using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;


namespace DriveApiTest3
{
    class NameGetter
    {
        public static string getName(string fileId,string pathServiceAccount)
        {
            var PathToServiceAccountKeyFile = @pathServiceAccount;
            GoogleCredential credential = GoogleCredential
                    .FromFile(PathToServiceAccountKeyFile)
                    .CreateScoped(new[] { DriveService.ScopeConstants.Drive });

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });
            string fileName = service.Files.Get(fileId).Execute().Name;

            return fileName;
        }
    }
}
