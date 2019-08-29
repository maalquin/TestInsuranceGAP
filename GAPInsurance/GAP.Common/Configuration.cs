using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Common
{
    public class Configuration
    {
        public static string GetConnectionStringForKey(string key)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;

            return string.IsNullOrEmpty(connectionString) ? string.Empty : connectionString;
        }
    }
}
