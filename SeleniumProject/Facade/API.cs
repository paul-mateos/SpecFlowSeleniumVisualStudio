using SP_Automation.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SP_Automation.Facade
{
    public class API
    {

        public string url;
        public string host;
        public string webservice;
        //public string contentType;
        public string requestBody;
        public string requestMethod;
        private string fullUrl;
        private int contentLength = 0;
        private string contentType = "application/json";
        public APICommons apiRequest = new APICommons();
        private List<Parameter> parameters = new List<Parameter>();
       

        public string buildUrlParam(string key, string value)
        {
            if (value == null || value.Length == 0) return "";

            return  key + "=" + value + "&";

        }

        public virtual string getFullUrl()
        {
            string host = Properties.Settings.Default.Environment;
            fullUrl = "http://" + host + "/" + webservice;
            string urlParam = "?";
            if(parameters.Count > 0)
            {
                foreach (var p in parameters)
                {
                    string keyValue = p.Value;
                    if (keyValue.Equals(""))
                    {
                        keyValue = getKeyValue(p.Key);
                    }
                    urlParam = urlParam + buildUrlParam(p.Key, keyValue);
                    // Need to be generic for different parameters
                }
                fullUrl = fullUrl + urlParam;
            }
           
            return fullUrl;
        }


        protected string getKeyValue(string key)
        {
            string value = "";
            switch (key)
            {
                case "sid":
                    value= getSessionID("","");
                    break;
                case "fn":
                   value = getFilePath();
                    break;

            }
            return value;
        }

        protected string getFilePath()
        {
            return apiRequest.getFilePath();
        }

        public void addParameters(string key, string value)
        {
            var parameter = new Parameter { Key = key, Value = value  };
            parameters.Add(parameter);
        }

        public void SendRequest()
        {
            getFullUrl();
            string value =  Regex.Replace(this.requestBody, @"\t|\n|\r", "");
            apiRequest.sendPOSTRequest(fullUrl, value, requestMethod,contentType,contentLength);
            //  RestAPI.newRequest(address).GetAndVerifyStatus(address + GenUrlString(), HttpStatusCode.OK);
        }

        public WebResponse recieveResponse()
        {

            return apiRequest.recieveResponse(); //apiRequest.getUserImportResponse()
        }

        public string getSessionID(string userName,string pwd)
        {
            return apiRequest.getSessionID(userName,pwd);
        }

        public class Parameter
        {
            public Parameter()
            {
                Parameters = new List<Parameter>();
            }

            public string Key { get; set; }

            public string Value { get; set; }

            public List<Parameter> Parameters { get; set; }
        }
    }
}

    
