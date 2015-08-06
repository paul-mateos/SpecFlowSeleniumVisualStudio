using System;
using TechTalk.SpecFlow;
using Panviva.LiveAPI;
using SP_Automation.Tests;
using SP_Automation;


namespace SpecFlowProject
{
    [Binding]
    public class MessageNotificationOnUserNotLoggedInSteps
    {
        readonly static string EP_BaseURL = "http://api.worldbank.org/countries?format=json";
        readonly string EP_OpenDocuement = EP_BaseURL + "&api=OpenDocuement";
        readonly string EP_DoSearch = EP_BaseURL + "&api=DoSearch";
        readonly string EP_DoCshSearch = EP_BaseURL + "&api=DoCshSearch";

        /**
         * key/value stored in Scenario Context
         */
        readonly string KEY_API = "APIObject";
       

        [Given(@"a OpenDocument is issued with '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenAOpenDocumentIsIssuedWith( string ApiKey , string FindUserBy , string User, string DocumentID , string Version , string SectionID , string AnchorName , string DateTime , string Description , string Actions)
        {
            DocumentRequest req = LiveAPI.NewOpenDocument(EP_OpenDocuement);
            req.ApiKey = ApiKey;
            req.Action = Actions;
            req.FindUserBy = FindUserBy;
            req.User = User;
            req.Version = Version;
            req.DocumentID = DocumentID;
            req.SectionID = SectionID;
            req.AnchorName = AnchorName;

            req.Send();
           // RestAPI.newRequest(EP_OpenDocuement + req.GenUrlString()).Post();

            /*
             *RestAPI.newRequest(EP_OpenDocuement).addParam("ApiKey", ApiKey).addParam("FindUserBy", FindUserBy, "")
                   .addParam("User", User).addParam("DocumentID", DocumentID)
                   .addParam("Version", Version, "").addParam("SectionID", SectionID, "")
                   .addParam("AnchorName", AnchorName, "").addParam("Description", Description, "")
                   .addParam("Actions", Actions, "").Post();
            */

            ScenarioContext.Current.Add(KEY_API, req);

        }

        [Given(@"a DoSearch is issued with '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenADoSearchIsIssuedWith(string ApiKey, string FindUserBy, string User, string Query, string Filters, string DateTime, string Description, string ShowFirstResult, string Actions)
        {
            SearchRequest req = LiveAPI.NewSearchRequest(EP_DoSearch);
            req.ApiKey = ApiKey;
            req.Action = Actions;
            req.FindUserBy = FindUserBy;
            req.User = User;
            req.Query = Query;
            req.Filters = Filters;
        //    req.ShowFirstResult = ShowFirstResult;
            req.Send();
            
          /*  RestAPI.newRequest(EP_DoSearch).addParam("ApiKey", ApiKey).addParam("FindUserBy", FindUserBy, "")
                   .addParam("User", User).addParam("Query", Query)
                   .addParam("Filter", Filters, "").addParam("ShowFirstResult", ShowFirstResult, "")
                   .addParam("Description", Description, "")
                   .addParam("Actions", Actions, "").Post();
            */
          
            ScenarioContext.Current.Add(KEY_API, req);
        
        }

        [Given(@"a DoCshSearch is issued with '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void GivenADoCshSearchIsIssuedWith(string ApiKey , string FindUserBy , string User   , string Query , string Filters  , string DateTime , string Description  , string ShowFirstResult  , string Actions)
        {
            CSHSearchRequest req = LiveAPI.NewCSHSearchRequest(EP_DoCshSearch);
            req.ApiKey = ApiKey;
            req.Action = Actions;
            req.FindUserBy = FindUserBy;
            req.User = User;
            req.Query = Query;
            req.Filters = Filters;

            req.Send();

            ScenarioContext.Current.Add(KEY_API, req);
            

        }
        
        [When(@"I click on the Notfication item")]
        public void WhenIClickOnTheNotficationItem()
        {
          SupportPoint.Notification.ClickNotificationCenter();
        }
        
        [Then(@"I should see the Notification on the top of list of unread messages")]
        [Then(@"I should see notifications pending on support point")]
        public void ThenIShouldSeeTheNotificationOnTheTopOfListOfUnreadMessages()
        {
     
        }
        
        [Then(@"I should see Type of Messages, Alert level, Time, and Message description for the notifcation")]
        public void ThenIShouldSeeTypeOfMessagesAlertLevelTimeAndMessageDescriptionForTheNotifcation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see the Notification Item disapear from notification list")]
        public void ThenIShouldSeeTheNotificationItemDisapearFromNotificationList()
        {
            ScenarioContext.Current.Get<LiveApiRequest>();
        }


        [Then(@"I should be redirected to the '(.*)' of the document in viewer")]
        public void ThenIShouldBeRedirectedToThe_PgOfTheDocumentInViewer(string result)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be redirected to the search result and should see <NumOfDocsShouldShow> docs")]
        public void ThenIShouldBeRedirectedToTheSearchResultAndShouldSeeDocs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be redirected to the CSH search result and should see <NumOfDocsShouldShow> docs")]
        public void ThenIShouldBeRedirectedToTheCSHSearchResultAndShouldSeeDocs(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [AfterScenario("MessageNotification_ActiveUser")]
        public static void AfterScenario()
        {
           SupportPoint.LogIn.LogOut();
        }
    }
}
