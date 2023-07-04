using System.IO;
using Newtonsoft.Json;
using ReportPortal.Business.Structures.Entities;
using Serilog;

namespace ReportPortal.Tests.Helpers
{
    public static class DataProvider
    {
        public static string GetApplicationUrl()
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}appconfig.json"))!;
            return jsonFile["url"];
        }

        public static string GetBrowserType()
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}appconfig.json"))!;
            return jsonFile["browserType"];
        }

        public static UserEntity GetUser(string userName)
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText($"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}users.json"))!;
            UserEntity userEntity = new()
            {
                Login = jsonFile[userName]["login"],
                Password = jsonFile[userName]["password"],
                Token = jsonFile[userName]["token"]
            };

            Log.Information("User has been created");
            return userEntity;
        }
    }
}
