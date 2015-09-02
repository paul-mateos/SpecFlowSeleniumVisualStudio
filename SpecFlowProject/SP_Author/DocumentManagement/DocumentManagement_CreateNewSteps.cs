using SP_Automation.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_CreateNewSteps
    {
        [Given(@"I have selected (.*)")]
        [When(@"I have selected (.*)")]
        [Then(@"I have selected (.*)")]
        public void WhenIHaveSelectedFolder(string newtype)
        {
            SupportPoint.DocumentManagmentNew.clickFolder(newtype);
        }

        [Given(@"I have entered Type (.*) Name (.*) Description (.*)")]
        [When(@"I have entered Type (.*) Name (.*) Description (.*)")]
        [Then(@"I have entered Type (.*) Name (.*) Description (.*)")]
        public void IHaveEnteredTypeNameDescription(string type, string name, string description)
        {
            SupportPoint.DocumentManagmentNew.fillIn(type, name, description);
        }

        [Given(@"I have entered Type (.*) document")]
        [When(@"I have entered Type (.*) document")]
        [Then(@"I have entered Type (.*) document")]
        public void IHaveEnteredType(string type)
        {
            SupportPoint.DocumentManagmentNew.SetType(type);
        }
    }
}
