using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefa.App.Data
{
    public class AppSettingsService
    {
        private readonly IConfiguration _config;

        public AppSettingsService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public string GetBaseUrl()
        {
            return _config.GetValue<string>("MySettings:BaseUrl");
        }
    }
}
