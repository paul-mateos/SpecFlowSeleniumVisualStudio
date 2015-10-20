using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SeleniumProject.API

{
    public class APICommons
    {
        public string username{ get; set; }
        public string password { get; set; }
       
            private string folderName;
            private string fileName;
            private string environment;
            public string SessionID;
            private string filePath;
            private string folderPath;
            private string protocol;
            private HttpWebRequest request;
            private WebResponse response;
            private Stream dataStream;
            private StreamReader reader;
            private string Url;
            private string fullUrl;
            public APICommons()
            {
                this.username = Properties.Settings.Default.username;
                this.password = Properties.Settings.Default.password;
                this.folderName = Properties.Settings.Default.folderName;
                this.fileName = Properties.Settings.Default.fileName;
                this.environment = Properties.Settings.Default.Environment;
                this.protocol = Properties.Settings.Default.Protocol;
               // CreateTestEnvironment();

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
            sendPOSTRequest(fullUrl, "", "POST", "application/json", 0);
        }

            public string buildUrlParam(string key, string value)
            {
                if (value == null || value.Length == 0) return "";

                return "&" + key + "=" + value;


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

        public string getFilePath()
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

            public string getSessionID(string userName, string pwd)
            {
            try
            {
                if (userName.Equals(""))
                {
                    userName = this.username;
                }
                if (pwd.Equals(""))
                {
                    pwd = this.password;
                }
                string url = protocol + this.environment+ "/WebService.svc/rest_all/Accounts/Login";
                string requestBody = "{ \"ApplicationID\":0, \"ForcedLogin\":true, \"Instance\":\"" + environment +"\",\"Password\":\"" + pwd + "\",\"UserName\":\"" + userName + "\"}";

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
                        this.SessionID = (string)obj["Response"]["SessionID"];
                    }
                    else if (response.ContentType.Equals("application/xml; charset=utf-8"))
                    {
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.LoadXml(responseFromServer);
                        XmlNodeList nodeList = xmldoc.GetElementsByTagName("SessionID");
                       foreach (XmlNode node in nodeList)
                        {
                            this.SessionID = node.InnerText;
                        }

                    }
                }
                //write if to success = true
                
                closeAll();
                return this.SessionID;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                throw new Exception(response.StatusCode + ex.Message);
           
            }

        }

            public void sendPOSTRequest(String url, String requestBody,string method,string contentType,int contentLength)
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.Accept = contentType;// "application/xml";
                request.ContentType = contentType +"; charset=utf-8";
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

        public WebResponse recieveResponse()
        {
            try
            {
                WebResponse recivedResponse=null;
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


        public WebResponse AsyncResponse(string fullUrl)
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


            protected void closeAll()
            {
            
                reader.Close();
                dataStream.Close();
             }
         }

}


