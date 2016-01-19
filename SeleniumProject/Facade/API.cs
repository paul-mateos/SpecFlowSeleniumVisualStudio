using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeleniumProject.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace SeleniumProject.Facade
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
        public static string environment;
        public static string protocol;
        //private string contentType = "application/xml";
        //public static APICommons apiRequest = new APICommons();
        private static List<Parameter> parameters = new List<Parameter>();
        public static string roleID = "";

        private static string Url;
        private static string filePath;
        private static string folderPath;
      
        private static Stream dataStream;
        private static StreamReader reader;
        private static  HttpWebRequest request;
        private static WebResponse response;
        public static string password;
        public static string username;
        private string folderName = "";
        private string fileName = "";


        public API()
        {
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;

            environment = ConfigurationManager.AppSettings.Get("Environment");
            protocol = ConfigurationManager.AppSettings.Get("Protocol");
            username = ConfigurationManager.AppSettings.Get("Username");
            password = ConfigurationManager.AppSettings.Get("Password");
        }

        public static string getFullUrl()
        {


            fullUrl = protocol + environment + "/" + webservice;
            string urlParam = "?";
            if (parameters.Count > 0)
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
                    value = getSessionID("", "");
                    break;
                case "fn":
                    value = getFilePath();
                    break;

            }
            return value;
        }

        //protected static string getFilePath()
        //{
        //    return apiRequest.getFilePath();
        //}

        public static void addParameters(string key, string value)
        {
            var parameter = new Parameter { Key = key, Value = value };
            parameters.Add(parameter);
        }

        public static void SendRequest()
        {
            getFullUrl();
            string value = Regex.Replace(requestBody, @"\t|\n|\r", "");
            string XMLvalue = Regex.Replace(requestXMLBody, @"\t|\n|\r", "");
            sendPOSTRequest(fullUrl, value, requestMethod, "application/json", contentLength);
        }

        //public static WebResponse recieveResponse()
        //{

        //    return apiRequest.recieveResponse();
        //}

        public static WebResponse recieveGetAsyncResponse()
        {

            return AsyncResponse(fullUrl);
        }

        //public static string getSessionID(string userName, string pwd)
        //{
        //    return getSessionID(userName, pwd);
        //}

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

        public void setURL(String url)
        {
            Url = url;
        }

        public void createFullUrl(String sid, String fn)
        {
            fullUrl = Url + buildUrlParam(sid, SessionID) + buildUrlParam(fn, filePath);

        }

        public void createAPIRequest()
        {
            sendPOSTRequest(fullUrl, "", "POST", "application/json", 0);
        }

        //public string buildUrlParam(string key, string value)
        //{
        //    if (value == null || value.Length == 0) return "";

        //    return "&" + key + "=" + value;


        //}


        public static string buildUrlParam(string key, string value)
        {
            if (value == null || value.Length == 0) return "";

            return key + "=" + value + "&";

        }

        protected void CreateTestEnvironment()
        {
            createFilepath();
            if (Directory.Exists(folderPath))
            {
                string[] list = GetFileNames(folderPath, "*.csv");

                filePath = folderPath + @"\" + list[0];
            }

        }

        public static string getSessionID(string userName, string pwd)
        {
            try
            {
                if (userName.Equals(""))
                {
                    userName = username;
                }
                if (pwd.Equals(""))
                {
                    pwd = password;
                }
                string url = protocol + environment + "/WebService.svc/rest_all/Accounts/Login";
                string requestBody = "{ \"ApplicationID\":0, \"ForcedLogin\":true, \"Instance\":\"" + environment + "\",\"Password\":\"" + pwd + "\",\"UserName\":\"" + userName + "\"}";

                // send POST request
                sendPOSTRequest(url, requestBody, "POST", "application/json", 0);
                WebResponse response = recieveResponse();
                //getResponse

                response = request.GetResponse();
                string statusCode = ((HttpWebResponse)response).StatusCode.ToString();
                string status = (((HttpWebResponse)response).StatusDescription).ToString();
                if (statusCode.Equals("OK"))
                {
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    if (response.ContentType.Equals("application/json; charset=utf-8"))
                    {
                        Object values = JsonConvert.DeserializeObject(responseFromServer);
                        JObject obj = JObject.Parse(values.ToString());
                        SessionID = (string)obj["Response"]["SessionID"];
                    }
                    else if (response.ContentType.Equals("application/xml; charset=utf-8"))
                    {
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.LoadXml(responseFromServer);
                        XmlNodeList nodeList = xmldoc.GetElementsByTagName("SessionID");
                        foreach (XmlNode node in nodeList)
                        {
                            SessionID = node.InnerText;
                        }

                    }
                }
                //write if to success = true

                closeAll();
                return SessionID;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                throw new Exception(response.StatusCode + ex.Message);

            }

        }


        public static string getFilePath()
        {
            return filePath;
        }

        private static string[] GetFileNames(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }

        private void createFilepath()
        {
            folderPath = @"\\" + environment + @"\" + folderName;
            filePath = folderPath + @"\" + fileName;

        }

        public static void sendPOSTRequest(String url, String requestBody, string method, string contentType, int contentLength)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Accept = contentType;// "application/xml";
            request.ContentType = contentType + "; charset=utf-8";
            request.ContentLength = contentLength;
            if (requestBody != "")
            {

                byte[] data = Encoding.UTF8.GetBytes(requestBody);
                request.ContentType = contentType + "; charset=utf-8";
                request.ContentLength = data.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
            }

        }

        private JObject GetResponse()
        {
            try
            {
                response = request.GetResponse();
                string statusCode = ((HttpWebResponse)response).StatusCode.ToString();
                string status = (((HttpWebResponse)response).StatusDescription).ToString();
                if (statusCode.Equals("OK"))
                {
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

                    Object values = JsonConvert.DeserializeObject(responseFromServer);
                    JObject obj = JObject.Parse(values.ToString());

                    return obj;
                }

                else
                {
                    return null;
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);

                return null;
            }
        }

        public static WebResponse recieveResponse()
        {
            try
            {
                WebResponse recivedResponse = null;
                Task.Run(async () =>
                {

                    recivedResponse = await request.GetResponseAsync();

                }).GetAwaiter().GetResult();
                return recivedResponse;

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                return response;
            }

        }


        public static WebResponse AsyncResponse(string fullUrl)
        {
            var webReq = (HttpWebRequest)WebRequest.Create(fullUrl);
            WebResponse responseMsg = null;

            Task.Run(async () =>
            {

                responseMsg = await webReq.GetResponseAsync();

            }).GetAwaiter().GetResult();

            return responseMsg;

        }

        public void getUserImportResponse()
        {
            //getResponse
            JObject obj = GetResponse();
            if (obj != null)
            {
                string success = (string)obj["Success"];
                if (success.Equals("true"))
                {
                    Console.WriteLine("Sucessful");
                }
                else if (success.Equals("false"))
                {
                    Console.WriteLine(obj["ErrorMessage"]);
                }
            }
            closeAll();
        }


        protected static void closeAll()
        {

            reader.Close();
            dataStream.Close();
        }
    }  
}

    
