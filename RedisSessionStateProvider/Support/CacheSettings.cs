using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisSessionStateProvider.Support
{
    public class CacheSettings
    {
        private static string serviceName = "session-replication";
        public static String BuildConnectionString()
        {
            string conString = null;

            if (ServerConfig.CloudFoundryServices != null)
            {
                Service service = ServerConfig.CloudFoundryServices.Services.FirstOrDefault(s => s.Name == serviceName || s.Label == serviceName || s.Tags.Contains(serviceName));
                if (service != null)
                {
                    string host = service.Credentials["host"].Value;
                    string port = service.Credentials["port"].Value;
                    string password = service.Credentials["password"].Value;

                    conString = $"{host}:{port},password={password},ssl=false";
                }
            }
            return conString;
        }
    }
}