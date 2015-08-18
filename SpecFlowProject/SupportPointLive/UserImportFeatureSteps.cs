using SP_Automation.REST;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SupportPointLive
{
    [Binding]
    public class UserImportFeatureSteps
    {
        private UserImport import;
        [Given(@"environment testFolder name and import file")]
        public void GivenEnvironmentTestFolderNameAndImportFile()
        {
            import = new UserImport();
            import.CreateTestEnvironment();
        }
        
        [Given(@"I have session ID")]
        public void GivenIHaveSessionID()
        {
            import.getSessionID();
        }

        [Given(@"an API definition ""(.*)""")]
        public void GivenAnAPIDefinition(string url)
        {
            import.setURL(url);
        }



        [Given(@"request type ""(.*)"" , ""(.*)""")]
        public void GivenRequestType(string sid, string fn)
        {
            import.createFullUrl(sid, fn);
        }


        [When(@"the request is executed")]
        public void WhenTheRequestIsExecuted()
        {
            import.createAPIRequest();
        }

        [Then(@"response status as ""(.*)"" , ""(.*)"" as ""(.*)""")]
        public void ThenResponseStatusAsAs(string p0, string p1, string p2)
        {
            import.getUserImportResponse();
        }

    }
}
