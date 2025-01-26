using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace OrderEats.Library.Common.Helper
{
    public class ConfigHelper
    {
        public static object GetConfig(string key)
        {
            try 
            {
                var path = Directory.GetCurrentDirectory();
                string txt = File.ReadAllText($@"{path}\\config.json");
                dynamic dyn = JsonObject.Parse(txt);
                return dyn[key];
            }
            catch(Exception ex)
            {
                // log todo here 
                return null;
            }
        }

        public static string GetConfigString(string key)
        {
            try
            {
                return GetConfig(key)?.ToString();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
