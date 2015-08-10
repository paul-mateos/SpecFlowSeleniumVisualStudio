using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.LiveAPI_P1
{
    [Binding]
    public sealed class MessageNotificationSteps
    {

        /**
         *  test data: 
         * 
         *  assumptions:
         *     user: aa exists with viewer permission
         *     
         *  validApiKey = xxxxxxxx
         *  
         */
/**
        [When(@"there is no message notification")]
        
        public void WhenThereIsNoMessageNotification()
        {
            SupportPoint_MessageNotification.AcknowledgeAllNotification();

        }

        [Then(@"message notification is invisible")]
        [Then(@"I should not get notifications")]
        public void ThenMessageNotificationIsInvisible()
        {
            SupportPoint_MessageNotification.VerifyNoMessageNotification();
        }

        [When(@"a Notification is issued from :")]
        public void WhenANotificationIsIssuedFrom(Table table)
        {
            foreach(TableRow r in table.Rows) 
            {
               string s;
               r.TryGetValue("notification", out s);
               
                switch (s)
                {
                    case "OpenDocumentNotification": LiveAPI.IssueOpenDocumentationNotification(); break;
                    case "SearchNotification": LiveAPI.IssueOpenDocumentationNotification(); break;
                    case "CSHSearchNotification": LiveAPI.IssueOpenDocumentationNotification(); break;
                    default: throw new Exception("unsupported test value:" + s);
                }
                ScenarioContext.Current['type']=s;
            }
        }

        [Then(@"I should see notifications pending on support point")]
        public void ThenIShouldSeeNotificationsPending()
        {
            SupportPoint_MessageNotification.VerifyMessageNotificationPending();
        }

        [When(@"I click on notifications")]
        public void WhenIClickOnNotifications()
        {
            SupportPoint_MessageNotification.OpenNotificationList();
        }

        [Then(@"I should see the Notification in the list of unread messages")]
        public void ThenIShouldSeeTheNotificationInTheListOfUnreadMessages()
        {
            SupportPoint_MessageNotification.VerifyNotificationInList(ScenarioContext<String>.Current['type']);
        }

        [Then(@"I should see Type of Messages, Alert level, Time, and Message description for each alert")]
        public void ThenIShouldSeeTypeOfMessagesAlertLevelTimeAndMessageDescriptionForEachAlert()
        {
            SupportPoint_MessageNotification.VerifyNotificationInList(
                type: ScenarioContext.Current["type"],
                alertLevel: ScenarioContext.Current["alertLevel"],
                time: ScenarioContext.Current["time"],
                description: ScenarioContext.Current["description"]
                );
        }

        [When(@"I click on the Notification item")]
        [When(@"I click on it")]
        public void WhenIClickOnTheNotificationItem()
        {
           SupportPoint_MessageNotification.Acknowledge(type:ScenarioContext.Current["type"]);
        }

        [Then(@"it should disapear from notification list")]
        public void ThenItShouldDisapearFromNotificationList()
        {
            SupportPoint_MessageNotification.VerifyNotInNotificationInList(type:ScenarioContext.Current["type"]);
        }

        [Given(@"I received a OpenDocumentNotification")]
        public void GivenIReceivedAOpenDocumentNotification()
        {
           LiveAPI.IssueOpenDocumentationNotification();
           ScenarioContext.Current["type"]="OpenDocumentNotification";
           ScenarioContext.Current["docId"]="docId";
        }

  
        [Then(@"I should be redirected to the document in viewer")]
        public void ThenIShouldBeRedirectedToTheDocumentInViewer()
        {
            SupportPoint_MessageNotification.VerifyOpenedDocument(ScenarioContext.Current["docId"]);
        }

        [Given(@"I received a SearchNotification")]
        public void GivenIReceivedASearchNotification()
        {
           LiveAPI.IssueSearchNotification();
           ScenarioContext.Current["type"]="SearchNotification";
        }

        [Then(@"I should be redirected to search result in viewer")]
        public void ThenIShouldBeRedirectedToSearchResultInViewer()
        {
            SupportPoint_MessageNotification.VerifySearchResult();
        }

        [Given(@"I received a CSHSearchNotification")]
        public void GivenIReceivedACSHSearchNotification()
        {
           LiveAPI.IssueCSHSearchNotification();
           ScenarioContext.Current["type"]="CSHSearchNotification";
        }

        [Then(@"I should be redirected to CSH search result in viewer")]
        public void ThenIShouldBeRedirectedToCSHSearchResultInViewer()
        {
            SupportPoint_MessageNotification.VerifyCSHSearchResult();
        }
*/
        /*
        [Given(@"I received (.*) Notifications")]
        public void GivenIReceivedNotifications(int p0)
        {   
            int i = 0;
            while(i < p0)
            {
             if (i++ < p0) GivenIReceivedAOpenDocumentNotification();
             if (i++ < p0) GivenIReceivedACSHSearchNotification(); 
             if (i++ < p0) GivenIReceivedASearchNotification();  
            }

            ScenarioContext.Current["numOfNotifcations"]=p0;

        }

        [Then(@"I should see at least (.*) latest items on list")]
        public void ThenIShouldSeeAtLeastLatestItemsOnList(int p0)
        {
            Assert.AreEqual(p0, SupportPoint_MessageNotification.GetNumOfVisibleNotificationsOnList());
        }

        [Then(@"the list is scrollable to see all notifications")]
        public void ThenTheListIsScrollableToSeeAllNotifications()
        {
            Assert.AreEqual(ScenarioContext.Current["numOfNotifcations"], SupportPoint_MessageNotification.GetNumOfAllNotificationsOnList());
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            //nothing to do
        }

        [Given(@"I received Notifications")]
        public void GivenIReceivedNotifications()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I log in (.*) days later")]
        public void WhenILogInDaysLater(int p0)
        {
            ScenarioContext.Current.Pending();
            //not implemented yet
        }

        [Then(@"I should still get these notifications")]
        public void ThenIShouldStillGetTheseNotifications()
        {
           Assert.AreEqual(ScenarioContext.Current["numOfNotifcations"], SupportPoint_MessageNotification.GetNumOfNotificationsPending());
        }

*/
    } 
}
