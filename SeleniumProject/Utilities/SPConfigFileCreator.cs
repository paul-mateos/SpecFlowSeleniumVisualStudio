using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Utility
{
    public static class SPConfigFileCreator
    {

        public static void UpdateSPConfigFile(string Environment, string Filelocation)
        {
            string json = File.ReadAllText(Filelocation);
            Object values = JsonConvert.DeserializeObject(json);
            JObject obj = JObject.Parse(values.ToString());
            obj.Property("server").Value = Environment;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Filelocation, output);

        }


    }
}
