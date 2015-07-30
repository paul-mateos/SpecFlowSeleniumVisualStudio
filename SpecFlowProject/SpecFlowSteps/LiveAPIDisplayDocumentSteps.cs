using System;
using System.Threading;
using TechTalk.SpecFlow;
using SP_Automation.Tests;
using SP_Automation.PageModels;
using Panviva.Rest;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SpecFlow_SupportPoint
{
    [Binding]
    public class LiveAPI_DisplayDocumentSteps
    {
        const string endpointAddr = "http://api.worldbank.org/countries?format=json";

        DocumentRequest req;
        HttpResponseMessage resp;


        [Given(@"issues DisplayDocuementAPI to display DocumentId=([0-9]+) to User (Name|Id) in (.+)")]
        [When(@"issues DisplayDocuementAPI to display DocumentId=([0-9]+) to User (Name|Id) in (.+)")]
        public void WhenIssuesDisplayDocuementAPIToDisplayDocumentId(int DocId, String NameOrId, String UserListSeperateWithComma)
        {
            resp = null;
            req = new DocumentRequest();

            req.DocumentID = DocId;
            req.User = UserListSeperateWithComma;

            if (NameOrId == "Name") req.FindUserBy = DocumentRequest.FindUserByName;
            else req.FindUserBy = DocumentRequest.FindUserByID;
        }


        [When(@"SectionID=([0-9]+)")]
        public void WhenSessionID(int sessionId)
        {
            req.SectionID = sessionId;
        }

        [When(@"AnchorName=(.+)")]
        public void WhenSessionID(string name)
        {
            req.AnchorName = name;
        }

        [Then(@"documentId=([0-9]+) should be displayed in SupportPoint Viewer")]
        public void ThenThisDocumentIdShouldBeDisplayedOnSupportPointViewer(int docId)
        {
            if (resp == null) { resp = RestTest.GetShouldOK(endpointAddr); }

            //add Selenium verify
        }

        [Then(@"should get response with StatusCode=([0-9]+)")]
        public void ThenShouldGetResponseWithStatusCode(int statusCode)
        {
            if (resp == null) { resp = RestTest.GetAndVerifyStatus(endpointAddr, (System.Net.HttpStatusCode)statusCode); }
            else Assert.AreEqual(statusCode, resp.StatusCode);

            
        }
    }
}
