using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CrudApp.Common
{
    public static class Helpers
    {
        public static string GetConnectionString(string value)
        {
            return ConfigurationManager.ConnectionStrings[value].ConnectionString;
        }

    }
}
