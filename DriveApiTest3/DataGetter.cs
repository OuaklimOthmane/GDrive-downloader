using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveApiProject
{
    class DataGetter
    {
        private readonly IConfiguration configuration;

        public DataGetter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public (string id, string mimeType, string pathServiceAccount, string pathLocalStorage, string newPathLocalStorage) TestMethod()
        {

            var pathFromJsonFile = configuration.GetSection("pathServiceAccount").Value;
            var idFromJsonFile = configuration.GetSection("id").Value;
            var mimeTypeFromJsonFile = configuration.GetSection("mimeType").Value;
            var localStorageFromJsonFile = configuration.GetSection("pathLocalStorage").Value;
            var newLocalStorageFromJsonFile = configuration.GetSection("newPathLocalStorage").Value;


            var data = (pathServiceAccount: pathFromJsonFile, fileId: idFromJsonFile, mimeType: mimeTypeFromJsonFile, pathLocalStorage: localStorageFromJsonFile, newPathLocalStorage: newLocalStorageFromJsonFile);


            return data;
        }
    }
}
