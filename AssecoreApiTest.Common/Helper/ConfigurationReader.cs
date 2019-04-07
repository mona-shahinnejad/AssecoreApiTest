using System.Configuration;

namespace Common.Helpers
{
    public class ConfigurationReader
    {
        public static string ReadAppConfig(string key, string defaultValue, string seperator = "", string keySuffix = "")
        {
            string finalKey = key;
            if (!string.IsNullOrWhiteSpace(seperator) && !string.IsNullOrWhiteSpace(keySuffix))
            {
                finalKey += seperator + keySuffix;
            }

            return ConfigurationManager.AppSettings[finalKey] != null ? ConfigurationManager.AppSettings[finalKey]  : defaultValue;
        }
    }
}
