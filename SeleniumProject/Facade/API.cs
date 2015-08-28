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

        public static string url;
        public static string host;
        public static string webservice;
        public static string SessionID = "";
        public static string apiKey = "";
        public static string UserID;
        public static string requestBody = "";
        public static string requestXMLBody = "";
        public static string requestMethod;
        private static string fullUrl;
        private static int contentLength = 0;
        private string contentType = "application/xml";
        public static APICommons apiRequest = new APICommons();
        private static List<Parameter> parameters = new List<Parameter>();
        public static string roleID = "";

        public static string buildUrlParam(string key, string value)
        {
            if (value == null || value.Length == 0) return "";

            return  key + "=" + value + "&";

        }

        public static string getFullUrl()
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
                       
                        if (SessionID.Equals(""))
                        {
                            keyValue = getKeyValue(p.Key);
                        }
                        else
                        {
                            keyValue = SessionID;
                        }
                    }
                    urlParam = urlParam + buildUrlParam(p.Key, keyValue);
                    // Need to be generic for different parameters
                }
                fullUrl = fullUrl + urlParam;
            }
            parameters.Clear();
           
            return fullUrl;
        }


        protected static string getKeyValue(string key)
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

        protected static string getFilePath()
        {
            return apiRequest.getFilePath();
        }

        public static void addParameters(string key, string value)
        {
            var parameter = new Parameter { Key = key, Value = value  };
            parameters.Add(parameter);
        }

        public static void SendRequest()
        {
            getFullUrl();
            string value =  Regex.Replace(requestBody, @"\t|\n|\r", "");
            string XMLvalue = Regex.Replace(requestXMLBody, @"\t|\n|\r", "");
            apiRequest.sendPOSTRequest(fullUrl, value, requestMethod, "application/xml; charset=utf-8", contentLength);
        }

        public static WebResponse recieveResponse()
        {
            
            return apiRequest.recieveResponse(); //apiRequest.getUserImportResponse()
        }

        public static WebResponse recieveGetAsyncResponse()
        {

           return  apiRequest.AsyncResponse(fullUrl); //apiRequest.getUserImportResponse()
        }

        public static string getSessionID(string userName,string pwd)
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

    
