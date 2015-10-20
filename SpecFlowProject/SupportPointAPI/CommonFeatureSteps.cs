using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeleniumProject.API;
using SeleniumProject.Commons;
using SeleniumProject.Facade;
using SeleniumProject.Tests;
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
        public void GivenIHavePathVariables(TechTalk.SpecFlow.Table table)
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


                    Console.WriteLine("Response:Status " + statusCode.ToString());
                    clearFeatureContext();
                }
                else
                {
                    throw new Exception(statusCode);

                }

            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                throw new Exception(response.StatusCode + ex.Message);

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
                        API.apiKey = node.InnerText;
                        FeatureContext.Current.Add("ApiKey", API.apiKey);
                    }
                    Console.WriteLine("Response:Status OK");                   
                    clearFeatureContext();
                }
            }
           
        }

        [Given(@"I have an apiKey")]
        public void GivenIHaveAnApiKey()
        {
            CreateNewAPIKey();
            GetAPIKeyForUser();
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
            var t = new TechTalk.SpecFlow.Table(header);
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
            API.SessionID = API.getSessionID(uName, pwd);
            if (FeatureContext.Current.ContainsKey("SID"))
            {
                FeatureContext.Current.Remove("SID");
                FeatureContext.Current.Add("SID", API.SessionID);
            }
            else
            {
                FeatureContext.Current.Add("SID", API.SessionID);
            }
            Console.WriteLine("Session ID is retrived Sucessfully");

        }


        [Given(@"I have SessioID with username as ""(.*)"" and password as ""(.*)""")]
        [When(@"I have SessioID with username as ""(.*)"" and password as ""(.*)""")]
        [Then(@"I have SessioID with username as ""(.*)"" and password as ""(.*)""")]
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

        [Given(@"New User is Created sucessfully")]
        [When(@"New User is Created sucessfully")]
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
                        if (FeatureContext.Current.ContainsKey("UserID"))
                        {
                            FeatureContext.Current.Set(UserID, "UserID");
                            FeatureContext.Current.Set(SessionID, "SessionID");
                        }
                        else
                        {
                            FeatureContext.Current.Add("UserID", UserID);
                            FeatureContext.Current.Add("SessionID", SessionID);
                        }
                        
                    }
                    else
                    {
                        string errorCode = (string)obj["ErrorCode"];
                        string errorDesc = (string)obj["ErrorMessage"];
                        Console.WriteLine("CREATEUPDATEUSER:" + errorCode + errorDesc);
                        throw new Exception("Problems creating new user");
                       
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
            if (FeatureContext.Current.ContainsKey("UserName"))
            {
                FeatureContext.Current.Set(UserName, "UserName");
            }else
            {
                FeatureContext.Current.Add("UserName", UserName);
            }

            if (FeatureContext.Current.ContainsKey("Pwd"))
            {
                FeatureContext.Current.Set(password, "Pwd");
            }
            else
            {
                FeatureContext.Current.Add("Pwd", password);
            }
            GivenIWantToARequest("POST");
            GivenMyWebserviceIs("Webservice.svc/rest_all/Users/CreateUpdate");
            GivenIHaveAnAPIForAccountLogin();
            GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
            GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"Disabled\":true,\"IsSsoUser\":false,\"RoleID\":"+ roleID + ",\"User\":{\"Email\":\"TestAuthor@panviva.com\",\"FirstName\":\"Burke\",\"LastName\":\"Author\",\"Password\":\""+ password  +"\",\"UserID\":\"0\",\"UserName\":\""+ UserName +"\"}");
            WhenISendRequest();
            ThenNewUserIsCreatedSucessfully();

        }

        //Create a new automation image folder
        public void CreateNewImageFolder(string folderName)
        {
            //Check if folder already exists
            GivenIWantToARequest("GET");
            GivenMyWebserviceIs("WebService.svc/rest_all/ImageFolders");
            GivenSessionIDAsParameters();
            WhenISendRequest();
            if(TheAutomationImageFolderExists() ==  false)
            {
                FeatureContext.Current.Add("FolderName", folderName);
                GivenIWantToARequest("POST");
                GivenMyWebserviceIs("WebService.svc/rest_all/Images/Folders");
                GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
                GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"FolderName\":\"" + folderName + "\",\"CreateInFolderID\":0}");
                WhenISendRequest();
                ThenNewImageFolderIsCreatedSucessfully();
            }

            

        }

        //Create a new automation Document folder
        public void CreateNewDocumentFolder(string folderName)
        {
            //Check if folder already exists
            GivenIWantToARequest("GET");
            GivenMyWebserviceIs("WebService.svc/rest_all/ImageFolders");
            GivenSessionIDAsParameters();
            WhenISendRequest();
            if (TheAutomationImageFolderExists() == false)
            {
                FeatureContext.Current.Add("FolderName", folderName);
                GivenIWantToARequest("POST");
                GivenMyWebserviceIs("WebService.svc/rest_all/Images/Folders");
                GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
                GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"FolderName\":\"" + folderName + "\",\"CreateInFolderID\":0}");
                WhenISendRequest();
                ThenNewImageFolderIsCreatedSucessfully();
            }



        }
        //To clear featuure context which are not used 
        public void clearFeatureContext()
        {
            FeatureContext.Current.Remove("SID");
            //api.requestBody = "";
            API.requestBody = "";

        }

        // To create random user based on the role provided
        [Given(@"I create a new ""(.*)"" user")]
        [When(@"I create new ""(.*)""user ")]
        [Then(@"I create a new ""(.*)""user ")]
        public void ICreateANewUser(string role)
        {
            GivenIHaveSessioIDWithUsernameAsAndPasswordAs("", "");
            getRoleID(role);
            string userName =  UICommon.getRandomName(role);
            CreateNewUser(userName, "1", API.roleID);
            
        }

        // To create random user based on the role provided
        [Given(@"I create a new ""(.*)"" user with username ""(.*)""")]
        [When(@"I create a new ""(.*)"" user with username ""(.*)""")]
        [Then(@"I create a new ""(.*)"" user with username ""(.*)""")]
        public void ICreateANewUserWithName(string role, string userName)
        {
            GivenIHaveSessioIDWithUsernameAsAndPasswordAs("", "");
            getRoleID(role);
            CreateNewUser(userName, "1", API.roleID);

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
        [When(@"I Have a xml Requestbody")]
        [Then(@"I Have a xml Requestbody")]
        public void GivenIHaveAXmlRequestbody(string textBody)
        {
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

            API.requestXMLBody = API.requestXMLBody + textBody;
        }

        [Given(@"Delete user")]
        [When(@"Delete user")]
        [Then(@"Delete user")]
        public void ThenDeleteUser()
        {
            try
            {
                if (FeatureContext.Current.Get<string>("UserID") != null)
                {
                    GivenIWantToARequest("POST");
                    GivenMyWebserviceIs("WebService.svc/rest_all/Users/Delete");
                    GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
                    GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"UserIdsList\":[" + FeatureContext.Current.Get<string>("UserID") + "]");
                    WhenISendRequest();
                    ThenMyResultIsResponse();
                }
            }
            catch
            { }
        }

        [Given(@"Delete user with username (.*)")]
        [When(@"Delete user with username (.*)")]
        [Then(@"Delete user with username (.*)")]
        public void ThenDeleteUserWithUsername(string userName)
        {
           
            GivenIWantToARequest("POST");
            GivenMyWebserviceIs("WebService.svc/rest_all/Users/Delete");
            GivenIHaveARequestBodyOf(" \"SessionID\":\"\",");
            GivenIHaveARequestBodyOf("\"Instance\":\"localhost\",\"UserIdsList\":[" + FeatureContext.Current.Get<string>("UserID") + "]");
            WhenISendRequest();
            ThenMyResultIsResponse();
           
        }

        [Given(@"I have logged in to SP as a new ""(.*)""")]
        [When(@"I have logged in to SP as a new ""(.*)""")]
        [Then(@"I have logged in to SP as a new ""(.*)""")]
        public void GivenIHaveLoggedInToSPAsRole(string role)
        {
            GivenIHaveSessioIDWithUsernameAsAndPasswordAs("", "");
            getRoleID(role);
            string userName = UICommon.getRandomName(role.Substring(0,3));
            CreateNewUser(userName, "1", API.roleID);

            if (!SupportPoint.IsSupportPointOpen()) SupportPoint.OpenSupportPoint();
            SupportPoint.LogIn.Login(FeatureContext.Current.Get<string>("UserName"), FeatureContext.Current.Get<string>("Pwd"));

        }

        [Given(@"I create the Automation Document Folder")]
        [When(@"I create the Automation Document Folder")]
        [Then(@"I create the Automation Document Folder")]
        public void GivenICreateTheAutomationDocumentFolder()
        {
            //string FolderName = getRandomImageName();
            CreateNewDocumentFolder("Automation");

        }

        [Given(@"I create the Automation Image Folder")]
        [When(@"I create the Automation Image Folder")]
        [Then(@"I create the Automation Image Folder")]
        public void GivenICreateTheAutomationImageFolder()
        {
            //string FolderName = getRandomImageName();
            CreateNewImageFolder("Automation");

        }

        //[Given(@"New Image Folder is Created sucessfully")]
        //[When(@"New Image Folder is Created sucessfully")]
        //[Then(@"New Image Folder is Created sucessfully")]
        public void ThenNewImageFolderIsCreatedSucessfully()
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
                        string FolderID = (string)obj["Response"]["NewImageFolderId"];
                        string SessionID = (string)obj["Response"]["SessionID"];
                        FeatureContext.Current.Add("ImageFolderID", FolderID);
                        FeatureContext.Current.Add("SessionID", SessionID);
                    }
                    else
                    {
                        string errorCode = (string)obj["ErrorCode"];
                        string errorDesc = (string)obj["ErrorMessage"];
                        throw new Exception(errorCode + " " + errorDesc);
                    }
                }
                //else if (response.ContentType.Equals("application/xml; charset=utf-8"))
                //{
                //    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmldoc.NameTable);
                //    nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");

                //    XmlNodeList Responses = xmldoc.SelectNodes("//rest:Response", nsmgr);
                //    foreach (XmlNode responseNode in Responses)
                //    {
                //        if (responseNode.SelectSingleNode(".//rest:Success", nsmgr).InnerText == "True")
                //        {
                //            FeatureContext.Current.Add("ImageFolderID", responseNode.SelectSingleNode(".//rest:NewImageFolderId", nsmgr).InnerText);
                //            Console.WriteLine("Response:Create Folder Sucess");
                //        }
                //    }
                //}
                else
                {
                    throw new Exception("Unknown ContentType");
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ((HttpWebResponse)ex.Response);
                Console.WriteLine(response.StatusCode + ex.Message);
                throw new Exception(response.StatusCode + ex.Message);
            }
        }

        [Given(@"Automation Image Folder Exists")]
        [When(@"Automation Image Folder Exists")]
        [Then(@"Automation Image Folder Exists")]
        public bool TheAutomationImageFolderExists()
        {
            ThenMyResultIsResponse();
            if (response.ContentType.Equals("application/json; charset=utf-8"))
            {
                JObject obj = myJsonResponse;
                myJsonResponse = null;
                JToken t = (JToken)obj.SelectToken("Response").SelectToken("Trees");
                JArray a = (JArray)t.SelectToken("Childs");
                foreach (JObject child in a)
                {
                    if (child.SelectToken("FolderDescription").ToString() == "Images")
                    {
                        t = (JToken)child.SelectToken("Childs");
                        JArray f = (JArray)t;
                        foreach (JObject folder in f)
                        {
                            if (folder.SelectToken("FolderDescription").ToString() == "Automation")
                            {
                                FeatureContext.Current.Add("ImageFolderID", folder.SelectToken("FolderID").ToString());
                                return true;
                            }
                        }
                        return false;
                    }
                }
                throw new Exception("Folder Images does not exist");
            }
            else
            {
                throw new Exception("Response content type unknown");
            }
        }

       
        [Given(@"I created the Test Image in the Automation Folder")]
        [When(@"I created the Test Image in the Automation Folder")]
        [Then(@"I created the Test Image in the Automation Folder")]
        public void GivenICreatedTheTestImageInTheAutomationFolder()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
