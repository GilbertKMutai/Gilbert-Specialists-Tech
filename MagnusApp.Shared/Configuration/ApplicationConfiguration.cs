using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnusApp.Shared.Configuration
{
    public static class ApplicationConfiguration
    {
        private static IConfigurationRoot _config;

        static ApplicationConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _config = builder.Build();
        }
        public static string GetSetting(string key)
        {
            return _config[key];
        }
    }

}
