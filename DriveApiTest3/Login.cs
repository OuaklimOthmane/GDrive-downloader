using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System;


namespace DriveApiTest3
{
    class Login
    {
        public static DriveService serviceCreator(string pathServiceAccount)
        {
            var PathToServiceAccountKeyFile = @pathServiceAccount; // Inject the Path to the credentials.json !!

            GoogleCredential credential = GoogleCredential
                   .FromFile(PathToServiceAccountKeyFile)
                   .CreateScoped(new[] { DriveService.ScopeConstants.Drive });

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });

            return service;
        }
    }
}
