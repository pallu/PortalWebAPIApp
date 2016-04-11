using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalWebAPIApp.services
{
    public class UtilityService
    {
        public static string SerializeJson(object model)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(model);
        }
        public static T DeserializeJson<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
