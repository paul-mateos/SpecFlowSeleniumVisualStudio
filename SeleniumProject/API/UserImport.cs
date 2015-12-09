using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Panviva.LiveAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SeleniumProject.Facade;
using System.Configuration;

namespace SeleniumProject.REST
{

     public class UserImport
    {
        private string username;
        private string password;
        private string folderName;
        private string fileName;
        private string environment;
        private string protocol;
        public string SessionID;
        private string filePath;
        private string folderPath;
        private WebRequest request;
        private WebResponse response;
        private Stream dataStream;
        private StreamReader reader;
        private string Url;
        private string fullUrl;

        public UserImport()
        {

            
            
            this.folderName =  Properties.Settings.Default.folderName;
            this.fileName = Properties.Settings.Default.fileName;
            System.Configuration.Configuration config =
                  ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;

            this.environment = ConfigurationManager.AppSettings.Get("Environment");
            this.protocol = ConfigurationManager.AppSettings.Get("Protocol");
            this.username = ConfigurationManager.AppSettings.Get("Username");
            this.password = ConfigurationManager.AppSettings.Get("Password");
        }

        public void setURL(String url)
        {
            this.Url = url;
        }

        public void createFullUrl(String sid, String fn)
        {
            fullUrl = Url + buildUrlParam(sid, SessionID) + buildUrlParam(fn, filePath);
            
        }

        public void createAPIRequest()
        {
            sendPOSTRequest(fullUrl, "");
        }

        public string buildUrlParam(string key, string value)
        {
            if (value == null || value.Length == 0) return "";

            return "&" + key + "=" + value;


        }

        public void CreateTestEnvironment()
        {
            createFilepath();
            if (Directory.Exists(folderPath))
            {
               string[] list = GetFileNames(folderPath, "*.csv");
                filePath = folderPath + @"\" + list[0];
            }
           
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
            filePath =folderPath + @"\" + fileName;

        }

        public string getSessionID()
        {
            string url = protocol + environment+"/WebService.svc/rest_all/Accounts/Login";            
            string requestBody = "{ \"ApplicationID\":0, \"ForcedLogin\":true, \"Instance\":\"localhost\",\"Password\":\"" + this.password+ "\",\"UserName\":\"" + this.username + "\"}";

            // send POST request
            sendPOSTRequest(url, requestBody);
            //getResponse
            JObject obj = GetResponse();
            //write if to success = true
            this.SessionID = (string)obj["Response"]["SessionID"];
            closeAll();
            return this.SessionID;
            
        }

        public void sendPOSTRequest(String url, String requestBody)
        {
            request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = 0;
            if (requestBody != "")
            {
                byte[] data = Encoding.UTF8.GetBytes(requestBody);
                request.ContentType = "application/json";
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
                Debug.WriteLine(response.StatusCode + ex.Message);
               
                return null; 
            }
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
                    Debug.WriteLine("Sucessfully imported users list");
                }
                else if (success.Equals("false"))
                {
                    Debug.WriteLine(obj["ErrorMessage"]);
                }
            }
            closeAll();
        }


        protected void closeAll()
        {
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }

 }
