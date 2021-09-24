using Makonis.Common;
using System;
using System.IO;
using System.Text.Json;

namespace Makonis.Services
{
    public class FileSaverService : IFileSaverService
    {
        public string SaveUserDetailsToFile(User user)
        {
            try
            {
                var filePath = Constants.FilePath;
                string json = JsonSerializer.Serialize(user);
                File.WriteAllText(filePath, json);
                return filePath;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
