using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SP_Automation.API;
using SP_Automation.Facade;
using SP_Automation.Tests;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SupportPointAPI
{
    [Binding]
    public class CommonFeatureSteps:Steps
    {
        public APICommons apiRequest = new APICommons();
        private WebResponse response;
        //private API api;
        private Stream dataStream;
        private StreamReader reader;
        private JObject myJsonResponse;
        private XmlDocument xmldoc = new XmlDocument();

        public CommonFeatureSteps()
        {
            //api = new API();
        }

        //SPLive_CommonSteps splive_commonSteps = new SPLive_CommonSteps();

        [Given(@"I want to ""(.*)"" a request")]
        public void GivenIWantToARequest(string method)
        {
            //api.requestMethod = method;
            API.requestMethod = method;
        }

        [Given(@"My webservice is ""(.*)""")]
        public void GivenMyWebserviceIs(string apiDefinition)
        {
            //api.webservice = apiDefinition;
            API.webservice = apiDefinition;
        }

        [Given(@"I have path variables")]
        public void GivenIHavePathVariables(Table table)
        {
            if (table.RowCount != 0)
            {
                foreach (var row in table.Rows)
                {
                    //api.addParameters(row["Key"], row["Value"]);
                    API.addParameters(row["Key"], row["Value"]);
                }
            }
        }



        [Given(@"I have a request body of")]
        public void GivenIHaveARequestBodyOf(string textBody)
        {
            if (textBody.Contains("SessionID\":\""))
            {
                //if (api.SessionID != "")
                if (API.SessionID != "")
                {
                    //textBody = textBody.Replace(":\"", ":\"" + api.SessionID);
                    textBody = textBody.Replace(":\"", ":\"" + API.SessionID);
                }
                else if (FeatureContext.Current.Get<string>("SID") != "")
                {
                    textBody = textBody.Replace(":\"", ":\"" + FeatureContext.Current.Get<string>("SID"));
                }
            }
            
            if (textBody.Contains("AuthKey"))
            {
               
                    textBody = textBody.Replace(":\"", ":\"" + FeatureContext.Current.Get<string>("ApiKey"));
               
            }
            if (textBody.Contains("uName"))
            {
                if (FeatureContext.Current.Get<string>("UserName") != "")
                {
                    textBody = textBody.Replace("uName", FeatureContext.Current.Get<string>("UserName"));
                }
            }
          
            //api.requestBody = api.requestBody + textBody;
            API.requestBody = API.requestBody + textBody;
        }


        [When(@"I send request")]
        public void WhenISendRequest()
        {
            //if (!api.requestBody.Equals(""))
            if (!API.requestBody.Equals(""))
            {
                //api.requestBody = "{" + api.requestBody + "}";
                API.requestBody = "{" + API.requestBody + "}";
            }
            API.SendRequest();
        }



        

        [Then(@"My result is response")]
        public void ThenMyResultIsResponse()
        {
            try
            {
                response = null;
                //response = api.recieveResponse();
                response = API.recieveResponse();
                string statusCode = ((HttpWebResponse)response).StatusCode.ToString();
                string status = (((HttpWebResponse)response).StatusDescription).ToString();
                string type = response.ContentType;
               
                if (statusCode.Equals("OK"))
                {
                    dataStream = response.GetResponseStream();
                    reader = new StreamReader(dataStream, Encoding.UTF8);
                    string responseFromServer = reader.ReadToEnd();

                    if (type.Equals("application/json; charset=utf-8"))
                    {
                        Object values = JsonConvert.DeserializeObject(responseFromServer);
                        if (myJsonResponse == null)
                        {
                            myJsonResponse = JObject.Parse(values.ToString());
                        }
                        
                    }
                    else if (type.Equals("application/xml; charset=utf-8"))
                    {
                        xmldoc.LoadXml(responseFromServer);
                        myJsonResponse = null;
                    }
                   

                    Console.WriteLine("Response:Status OK");
                    clearFeatureContext();
                }

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);


            }
            
        }

        [Then(@"Get API Key")]
        public void ThenGetAPIKey()
        {
           //WebResponse apiResponse =  api.recieveGetAsyncResponse();
           WebResponse apiResponse = API.recieveGetAsyncResponse();
            string statusCode = ((HttpWebResponse)apiResponse).StatusCode.ToString();
            string status = (((HttpWebResponse)apiResponse).StatusDescription).ToString();
            string type = apiResponse.ContentType;
            if (statusCode.Equals("OK"))
            {
                dataStream = apiResponse.GetResponseStream();
                reader = new StreamReader(dataStream, Encoding.UTF8);
                string responseFromServer = reader.ReadToEnd();
                if (apiResponse.ContentType.Equals("application/xml; charset=utf-8"))
                {
                    xmldoc.LoadXml(responseFromServer);
                    XmlNodeList nodeList = xmldoc.GetElementsByTagName("ApiKey");
                    foreach (XmlNode node in nodeList)
                    {
                        //api.apiKey = node.InnerText;
                        API.apiKey = node.InnerText;
                        //FeatureContext.Current.Add("ApiKey", api.apiKey);
                        FeatureContext.Current.Add("ApiKey", API.apiKey);
                    }
                    Console.WriteLine("Response:Status OK");                   
                    clearFeatureContext();
                }
            }
           
        }

        // To create a new API in the database based on username, password and a SessionID
        public void CreateNewAPIKey()
        {
            string username = "";
            GivenIWantToARequest("POST");
            GivenMyWebserviceIs("WebService.svc/rest_all/ApiKey");
            GivenIHaveSessioIDWithUsernameAsAndPasswordAs("", "");
            GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
            if (FeatureContext.Current.ContainsKey("UserName"))
            {
               username = FeatureContext.Current.Get<string>("UserName");
            }
            GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"Name\":\"" + username + "\"");
            WhenISendRequest();
            getSessionIDForAPIKey();
        }

        // To get session based on response 
        public void getSessionIDForAPIKey()
        {
            try
            {
                ThenMyResultIsResponse();
                if (response.ContentType.Equals("application/json; charset=utf-8"))
                {
                    JObject obj = myJsonResponse;
                    myJsonResponse = null;
                    string value = obj["Success"].ToString();
                    if (value.Equals("true") || value.Equals("True"))
                    {
                       
                        //api.SessionID = (string)obj["Response"]["SessionID"];
                        API.SessionID = (string)obj["Response"]["SessionID"];
                        if (FeatureContext.Current.ContainsKey("SID"))
                        {
                            FeatureContext.Current.Remove("SID");
                            //FeatureContext.Current.Add("SID", api.SessionID);
                            FeatureContext.Current.Add("SID", API.SessionID);
                        }
                        else
                        {
                            //FeatureContext.Current.Add("SID", api.SessionID);
                            FeatureContext.Current.Add("SID", API.SessionID);
                        }
                        Console.WriteLine("Session ID is retrived Sucessfully");
                    }

                    else
                    {
                        string errorCode = (string)obj["ErrorCode"];
                        string errorDesc = (string)obj["ErrorMessage"];
                        Console.WriteLine("GETSESSIONIDFORAPIKEY:" + errorCode + errorDesc);
                    }
                }
                else if (response.ContentType.Equals("application/xml; charset=utf-8"))
                {
                    XmlNodeList nodeList = xmldoc.GetElementsByTagName("Success");
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.InnerText.Equals("true"))
                        {
                            XmlNodeList responses = xmldoc.GetElementsByTagName("Response");
                            foreach (XmlNode r in responses)
                            {
                                if (r.HasChildNodes)
                                {
                                    for (int i = 0; i < r.ChildNodes.Count; i++)
                                    {
                                        if (r.ChildNodes[i].Name.Equals("SessionID"))
                                        {
                                            //api.SessionID = r.ChildNodes[i].InnerText;
                                            API.SessionID = r.ChildNodes[i].InnerText;
                                            if (FeatureContext.Current.ContainsKey("SID"))
                                            {
                                                FeatureContext.Current.Remove("SID");
                                                //FeatureContext.Current.Add("SID", api.SessionID);
                                                FeatureContext.Current.Add("SID", API.SessionID);
                                            }
                                            else
                                            {
                                                //FeatureContext.Current.Add("SID", api.SessionID);
                                                FeatureContext.Current.Add("SID", API.SessionID);
                                            }
                                            Console.WriteLine("Session ID is retrived Sucessfully");
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }

                }

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                Environment.FailFast("GETSESSIONIDFORAPIKEY:FAILED");

            }

        }

        // To get an API key for given username and password
        public void GetAPIKeyForUser()
        {
            GivenIWantToARequest("GET");
            GivenMyWebserviceIs("WebService.svc/rest_all/ApiKey");
            GivenSessionIDAsParameters();
            WhenISendRequest();
            ThenGetAPIKey();         
        }
        
        public void GivenSessionIDAsParameters()
        {
            string[] header = { "Key", "Value" };
            string[] row1 = { "sid", "" };
            var t = new Table(header);
            t.AddRow(row1);
            GivenIHavePathVariables(t);
        }

        [Given(@"I have an API for Account Login")]
        public void GivenIHaveAnAPIForAccountLogin()
        {
            getSessioID("","");

        }

        private void getSessioID(string uName, string pwd)
        {
            //api.SessionID = api.getSessionID(uName, pwd);
            API.SessionID = API.getSessionID(uName, pwd);
            if (FeatureContext.Current.ContainsKey("SID"))
            {
                FeatureContext.Current.Remove("SID");
                //FeatureContext.Current.Add("SID", api.SessionID);
                FeatureContext.Current.Add("SID", API.SessionID);
            }
            else
            {
                //FeatureContext.Current.Add("SID", api.SessionID);
                FeatureContext.Current.Add("SID", API.SessionID);
            }
            Console.WriteLine("Session ID is retrived Sucessfully");

        }

        [Given(@"I have SessioID with username as ""(.*)"" and password as ""(.*)""")]
        public void GivenIHaveSessioIDWithUsernameAsAndPasswordAs(string userName, string pwd)
        {
            if (FeatureContext.Current.ContainsKey("UserName") && FeatureContext.Current.ContainsKey("Pwd"))
            {
                if (!(FeatureContext.Current.Get<string>("UserName").Equals("")) && !(FeatureContext.Current.Get<string>("Pwd").Equals("")))
                {
                    userName = FeatureContext.Current.Get<string>("UserName");
                    pwd = FeatureContext.Current.Get<string>("Pwd");
                }
            }
            getSessioID(userName, pwd);
        }

        [Then(@"New User is Created sucessfully")]
        public void ThenNewUserIsCreatedSucessfully()
        {
            try
            {
                
                ThenMyResultIsResponse();
                if (response.ContentType.Equals("application/json; charset=utf-8"))
                {
                    JObject obj = myJsonResponse;
                    myJsonResponse = null;
                    string value = obj["Success"].ToString();
                    if (value.Equals("true") || value.Equals("True"))
                    {
                        string UserID = (string)obj["Response"]["User"]["UserID"];
                        string SessionID = (string)obj["Response"]["SessionID"];
                        FeatureContext.Current.Add("UserID", UserID);
                        FeatureContext.Current.Add("SessionID", SessionID);
                    }
                    else
                    {
                        string errorCode = (string)obj["ErrorCode"];
                        string errorDesc = (string)obj["ErrorMessage"];
                        Console.WriteLine("CREATEUPDATEUSER:" + errorCode + errorDesc);
                       
                    }
                }
                else if (response.ContentType.Equals("application/xml; charset=utf-8"))
                {
                    XmlNodeList nodeList = xmldoc.GetElementsByTagName("Success");
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.InnerText.Equals("true"))
                        {
                            XmlNodeList responses = xmldoc.GetElementsByTagName("Response");
                            foreach (XmlNode r in responses)
                            {
                                if (r.HasChildNodes)
                                {
                                    for (int i = 0; i < r.ChildNodes.Count; i++)
                                    {
                                        string UserID = "";
                                        string SessionID = "";
                                        if (r.ChildNodes[i].Name.Equals("User"))
                                        {
                                            if (r.ChildNodes[i].HasChildNodes)
                                            {
                                                foreach (XmlNode user in r.ChildNodes[i])
                                                {
                                                    if (user.Name.Equals("a:UserID"))
                                                    {
                                                        UserID = user.InnerText;
                                                        FeatureContext.Current.Add("UserID", UserID);
                                                    }
                                                }
                                            }                                      
                                            
                                        }

                                        if (r.ChildNodes[i].Name.Equals("SessionID"))
                                        {
                                            SessionID = r.ChildNodes[i].InnerText;
                                            FeatureContext.Current.Add("SessionID", SessionID);
                                        }
                                        Console.WriteLine("Response:Sucess");
                                    }

                                }
                            }
                            return;                       
                        }
                        else if (node.InnerText.Equals("False"))
                        {                           
                            string errorCode = xmldoc.GetElementsByTagName("ErrorCode")[0].InnerText;
                            string errorDesc = xmldoc.GetElementsByTagName("ErrorMessage")[0].InnerText;
                            Console.WriteLine("CREATEUPDATEUSER:" + errorCode + errorDesc);
                        }
                    }
                    
                    
                }

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                Environment.FailFast("CREATEUPDATEUSER:FAILED");

            }
        }

        // To create a new User based on the provided Username, password and roleID

        public void CreateNewUser(string UserName, string password, string roleID)
        {
            FeatureContext.Current.Add("UserName", UserName);
            FeatureContext.Current.Add("Pwd", password);
            GivenIWantToARequest("POST");
            GivenMyWebserviceIs("Webservice.svc/rest_all/Users/CreateUpdate");
            GivenIHaveAnAPIForAccountLogin();
            GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
            GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"Disabled\":true,\"IsSsoUser\":false,\"RoleID\":"+ roleID + ",\"User\":{\"Email\":\"TestAuthor@panviva.com\",\"FirstName\":\"Burke\",\"LastName\":\"Author\",\"Password\":\""+ password  +"\",\"UserID\":\"0\",\"UserName\":\""+ UserName +"\"}");
            WhenISendRequest();
            ThenNewUserIsCreatedSucessfully();

        }

        //To clear featuure context which are not used 
        public void clearFeatureContext()
        {
            FeatureContext.Current.Remove("SID");
            //api.requestBody = "";
            API.requestBody = "";

        }

        // To create random user based on the role provided

        [Given(@"I have a new ""(.*)""")]
        public void GivenIHaveANew(string role)
        {
            GivenIHaveSessioIDWithUsernameAsAndPasswordAs("", "");
            getRoleID(role);
            string userName =  getRandomUserName(role);
            //CreateNewUser(userName, "1", api.roleID);
            CreateNewUser(userName, "1", API.roleID);

        }

        protected string getRandomUserName(string role)
        {
            string currentTime = DateTime.Now.ToString("hmmss");
            string sub = role.Substring(0, 3);
            return role.Substring(0, 3) + currentTime;
        }

        protected void getRoleID(string role)
        {
            try
            {
                GivenIWantToARequest("GET");
                GivenMyWebserviceIs("WebService.svc/rest_all/Users/RoleList");
                GivenSessionIDAsParameters();
                WhenISendRequest();
                ThenMyResultIsResponse();
                if (response.ContentType.Equals("application/json; charset=utf-8"))
                {
                    JObject obj = myJsonResponse;
                    myJsonResponse = null;
                    string value = obj["Success"].ToString();
                    if (value.Equals("true") || value.Equals("True"))
                    {
                        var roles = obj["Response"]["Roles"];
                        foreach (var r in roles)
                        {
                            if (r["Name"].ToString().Equals(role))
                            {
                                //api.roleID = r["Id"].ToString();
                                API.roleID = r["Id"].ToString();
                            }
                        }
                    }
                }
                else if (response.ContentType.Equals("application/xml; charset=utf-8"))
                {
                    XmlNodeList roles = xmldoc.GetElementsByTagName("Roles");

                    foreach (XmlNode r in roles)
                    {
                           if (r.HasChildNodes)
                            {
                            for (int i = 0; i < r.ChildNodes.Count; i++)
                            {
                                if (r.ChildNodes[i].HasChildNodes)
                                {
                                    string roleID = "";
                                    for (int y = 0; y < r.ChildNodes[i].ChildNodes.Count;y++)
                                    {                                        
                                        XmlNode innerNode = r.ChildNodes[i].ChildNodes[y];
                                        if (innerNode.Name.Equals("a:Id"))
                                        {                                            
                                            roleID = innerNode.InnerText;
                                        }
                                        if (innerNode.Name.Equals("a:Name"))
                                        {
                                            if (innerNode.InnerText.Equals(role))
                                            {
                                                //api.roleID = roleID;
                                                API.roleID = roleID;
                                                return;
                                            }
                                        }
                                    }
                                }
                                                               
                            }
                        }                       
                       
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                Environment.FailFast("ROLEID:FAILED");

            }
        }



        [Given(@"I Have a xml Requestbody")]
        public void GivenIHaveAXmlRequestbody(string textBody)
        {
            /*if (textBody.Contains(""))
            {
                if (api.SessionID != "")
                {
                    textBody = textBody.Replace("\">", "\">" + api.SessionID);
                }
                else if (FeatureContext.Current.Get<string>("SID") != "")
                {
                    textBody = textBody.Replace("\">", "\">"+ FeatureContext.Current.Get<string>("SID"));
                }
            }*/

            if (textBody.Contains("AuthKey"))
            {

                textBody = textBody.Replace("\">", "\">" + FeatureContext.Current.Get<string>("ApiKey"));

            }
            if (textBody.Contains("<User"))
            {
                if (FeatureContext.Current.Get<string>("UserName") != "")
                {
                    textBody = textBody.Replace(">\"\"", ">" + FeatureContext.Current.Get<string>("UserName"));
                }
            }

            //api.requestXMLBody = api.requestXMLBody + textBody;
            API.requestXMLBody = API.requestXMLBody + textBody;
        }

        [Then(@"Delete user")]
        public void ThenDeleteUser()
        {
            GivenIWantToARequest("POST");
            GivenMyWebserviceIs("WebService.svc/rest_all/Users/Delete");
            GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
            GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"UserIdsList\":[" + FeatureContext.Current.Get<string>("UserID")+"]");
            WhenISendRequest();
            ThenMyResultIsResponse();
    }

    }
}
